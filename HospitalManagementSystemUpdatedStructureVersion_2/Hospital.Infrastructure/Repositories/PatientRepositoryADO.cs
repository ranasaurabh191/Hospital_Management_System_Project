using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace Hospital.Infrastructure.Repositories;

public class PatientRepositoryADO : IPatientRepository
{
    private readonly string _connection;

    public PatientRepositoryADO(string connection)
    {
        _connection = connection;
    }

    // ADD PATIENT
    public void AddPatient(Patient patient)
    {
        using SqlConnection con = new SqlConnection(_connection);

        SqlCommand cmd = new SqlCommand(
            "INSERT INTO Patients(Name,Condition,DoctorId) VALUES(@name,@condition,@doctorId)", con);

        cmd.Parameters.AddWithValue("@name", patient.Name);
        cmd.Parameters.AddWithValue("@condition", patient.Condition);
        cmd.Parameters.AddWithValue("@doctorId", patient.DoctorId);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    // GET ALL PATIENTS
    public IEnumerable<Patient> GetPatients()
    {
        List<Patient> patients = new List<Patient>();

        using SqlConnection con = new SqlConnection(_connection);

        SqlCommand cmd = new SqlCommand("SELECT * FROM Patients", con);

        con.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            patients.Add(new Patient
            {
                PatientId = Convert.ToInt32(reader["PatientId"]),
                Name = reader["Name"].ToString() ?? "",
                Condition = reader["Condition"].ToString() ?? "",
                DoctorId = Convert.ToInt32(reader["DoctorId"])
            });
        }

        return patients;
    }

    // UPDATE PATIENT
    public void UpdatePatient(Patient patient)
    {
        using SqlConnection con = new SqlConnection(_connection);

        SqlCommand cmd = new SqlCommand(
            "UPDATE Patients SET Name=@name, Condition=@condition, DoctorId=@doctorId WHERE PatientId=@id", con);

        cmd.Parameters.AddWithValue("@name", patient.Name);
        cmd.Parameters.AddWithValue("@condition", patient.Condition);
        cmd.Parameters.AddWithValue("@doctorId", patient.DoctorId);
        cmd.Parameters.AddWithValue("@id", patient.PatientId);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    // DELETE PATIENT
    public void DeletePatient(int id)
    {
        using SqlConnection con = new SqlConnection(_connection);

        SqlCommand cmd = new SqlCommand(
            "DELETE FROM Patients WHERE PatientId=@id", con);

        cmd.Parameters.AddWithValue("@id", id);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    // FIND PATIENT BY NAME
    public Patient? FindPatient(string name)
    {
        using SqlConnection con = new SqlConnection(_connection);

        SqlCommand cmd = new SqlCommand(
            "SELECT * FROM Patients WHERE Name=@name", con);

        cmd.Parameters.AddWithValue("@name", name);

        con.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Patient
            {
                PatientId = Convert.ToInt32(reader["PatientId"]),
                Name = reader["Name"].ToString() ?? "",
                Condition = reader["Condition"].ToString() ?? "",
                DoctorId = Convert.ToInt32(reader["DoctorId"])
            };
        }

        return null;
    }
}