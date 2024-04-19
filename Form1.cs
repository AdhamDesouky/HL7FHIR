using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using hl7_test.Models;
using System.Net.Http;
namespace ConsoleApp1
{
    public partial class Form1 : Form
    {
        protected FhirClient _client;
        Dictionary<string, Patient> Patients_dic = new Dictionary<string, Patient>();//This dic mimics the database, once Patient added to server we save refrence to its logical id
        public Form1()
        {
            InitializeComponent();
            //Initialize Fhir client
            FhirClientSettings _settings = new FhirClientSettings()
            {
                PreferredFormat = ResourceFormat.Json,
            };
            //we use simplifier for testing and educational purposes
            _client = new FhirClient("https://fhir.simplifier.net/fhir20231616", _settings);
            _client.RequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRoYW1kZXNvdWt5IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiI4Mjc4ODE5Yy1kNWMzLTQ2YzgtYWY1ZS1lYzIyNjczMjk1MWUiLCJqdGkiOiJlOWRiOTI1NS1hODA2LTQ1ZjctOGYxNC03ZjliOGRlOTRkNGMiLCJleHAiOjE3MTM1ODk5NDksImlzcyI6ImFwaS5zaW1wbGlmaWVyLm5ldCIsImF1ZCI6ImFwaS5zaW1wbGlmaWVyLm5ldCJ9.59xoyNWN1itaSA4lwwZUs0mxwrrvM_fis3ZyU1YbY6Y.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiemVpbmFzYWxhaCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiNDcwYmU5ZDYtZDQ4ZC00YzQ3LWFjZjMtMTk5MjNjMDczMGY5IiwianRpIjoiNmE5ZjllODQtMmFhOC00OWQxLWE0NzItODBjYmRhNjAyNDhmIiwiZXhwIjoxNzEzNTA3MzgxLCJpc3MiOiJhcGkuc2ltcGxpZmllci5uZXQiLCJhdWQiOiJhcGkuc2ltcGxpZmllci5uZXQifQ.Nw1cPz5oS5aMtx5kJU5xuJWYfiOGVhLysYkK-aQv5j8");

        }
        private void Find_All_Patients_Btn_Click(object sender, EventArgs e)
        {

            var result = Find_Patient_By_Name(_client, "");
            //bind list to data grid view
            var _bind = result.resultList.Select(a => new { id = a.Id, Full_Name = a.FullName, Email = a.Email, BirthDate = a.Birthdate }).ToList();

            dataGridView1.DataSource = _bind;


            //dataGridView1.Columns["id"].Visible = false;

        }
        private void Find_Patient_Btn_Click(object sender, EventArgs e)
        {
            var result = Find_Patient_By_Name(_client, txt_Search_By_Name.Text);
            //bind list to data grid view
            var _bind = result.resultList.Select(a => new { id = a.Id, Full_Name = a.FullName, Email = a.Email, BirthDate = a.Birthdate }).ToList();
            dataGridView1.DataSource = _bind;
        }
        private void Add_Patient_Btn_Click(object sender, EventArgs e)
        {
            //bind information to patientDataModel
            PatientDataModel patientDataModel = new PatientDataModel();
            patientDataModel.FirstName = txt_fname.Text;
            patientDataModel.LastName = txt_LastName.Text;
            patientDataModel.Email = txt_Email.Text;
            patientDataModel.FullName = patientDataModel.FirstName + "" + patientDataModel.LastName;


            //check Is patient already inserted or not based on full name
            var result = Find_Patient_By_Name(_client, patientDataModel.FullName);

            //check number of resources
            if (result.resultList.Count > 0)
            {
                MessageBox.Show("already Added");
            }
            else
            {
                //fill in HL7 patient Model
                Patient patient = new Patient()
                {

                    Active = true,
                    Name = new List<HumanName>()
                {
                    new HumanName()
                    {
                        Family = patientDataModel.LastName,
                        Text = patientDataModel.FullName,
                        Given = new List<string>()
                        {
                            patientDataModel.FirstName
                        },
                         Use = HumanName.NameUse.Official
                    }
                },
                    Identifier = new List<Identifier>()
                    {
                        new Identifier()
                        {
                            Value = "1032702",
                            Use = Identifier.IdentifierUse.Usual,
                            System="urn:oid:0.1.2.3.4.5.6.7"

                        }
                    },
                    BirthDate = (new FhirDateTime(patientDataModel.Birthdate.Year, patientDataModel.Birthdate.Month, patientDataModel.Birthdate.Day)).ToString(),
                    Gender = patientDataModel.Gender ? AdministrativeGender.Male : AdministrativeGender.Female,
                    Telecom = new List<ContactPoint>()
                {
                    new ContactPoint()
                    {
                        System = ContactPoint.ContactPointSystem.Phone,
                        Value = patientDataModel.phoneNumber,
                        Use = ContactPoint.ContactPointUse.Mobile
                    },
                    new ContactPoint()
                    {
                        System = ContactPoint.ContactPointSystem.Phone,
                        Value = patientDataModel.EmergencyNumber,
                        Use = ContactPoint.ContactPointUse.Home
                    },
                     new ContactPoint()
                    {
                        System = ContactPoint.ContactPointSystem.Email,
                        Value = patientDataModel.Email,
                        Use = ContactPoint.ContactPointUse.Home
                    }
                }
                };

                var re = _client.Create<Patient>(patient);

                if (re.Id != null)
                {
                    MessageBox.Show("Patient added");
                    txt_fname.Text = "";
                    txt_LastName.Text = "";
                    txt_Email.Text = "";
                    Patients_dic.Add(re.Id, patient);
                }

            }
        }
        private void Update_Patient_Btn_Click(object sender, EventArgs e)
        {
            var patient = Find_Patient_By_Name(_client, txt_Search_By_Name.Text);
            if (patient != null)
            {
                var oldPatient = _client.Read<Patient>("Patient/" + patient.resultList.FirstOrDefault().Id);
                //Generate dummy Date
                DateTime dateTime = DateTime.Now;
                oldPatient.BirthDate = (new FhirDateTime(dateTime.Year, dateTime.Month, dateTime.Day)).ToString();

                //Update Patient
                var re = _client.Update<Patient>(oldPatient);
            }
            else
            {
                MessageBox.Show("Patient ID not found in the Dictionary");
            }

        }
        private void Delete_Patient_Btn_Click(object sender, EventArgs e)
        {

            var patient = Find_Patient_By_Name(_client, txt_Search_By_Name.Text);

            //string patientKey_LogicalID = Patients_dic.Where(x => x.Value.Name.FirstOrDefault().Text == txt_Search_By_Name.Text).FirstOrDefault().Key;
            //if (patientKey_LogicalID.Length != 0)
            if (patient != null)
            {
                //Delete Patient
                //_client.Delete("Patient/" + patientKey_LogicalID);
                _client.Delete("Patient/" + patient.resultList.FirstOrDefault().Id);
                MessageBox.Show("Patient Deleted");
            }
            else
            {
                MessageBox.Show("Patient ID not found in the Dictionary");
            }

        }
        public static PatientDataModelList Find_Patient_By_Name(FhirClient _client, string full_name)
        {
            //initialize search paramtreres
            SearchParams searchParams = new SearchParams()
            {
                Content = full_name,
            };
            //request sent
            var result = _client.Search<Patient>(searchParams);

            PatientDataModelList patients = new PatientDataModelList()
            {
                resultList = new List<PatientDataModel>(),
                searchKey = full_name
            };
            //check resopnse
            //convert each HL7 Patient Resource to PtientModel
            result.Entry.ForEach(p =>
            {
                var _p = p.Resource as Patient;
                PatientDataModel patient = new PatientDataModel()
                {
                    //fill in properties //check data availability to avoid exceptions!s
                    Id = _p.Id,
                    FullName = _p.Name.Any() ? string.IsNullOrEmpty(_p.Name.LastOrDefault().Text) ? _p.Name.LastOrDefault().Family : _p.Name.LastOrDefault().Text : "",
                    IdentityNumber = _p.Identifier.Any() ? _p.Identifier.LastOrDefault().Value : "",
                    Gender = _p.Gender == AdministrativeGender.Male,
                    Email = _p.Telecom.Any() ?
                                _p.Telecom.Where(x => x.System == ContactPoint.ContactPointSystem.Email).Any() ?
                                _p.Telecom.Where(x => x.System == ContactPoint.ContactPointSystem.Email).FirstOrDefault().Value : ""
                                : "",
                    Birthdate = Convert.ToDateTime(_p.BirthDate)
                };
                //add PtientModel object to result list
                patients.resultList.Add(patient);
            });

            return patients;

        }

    }
}