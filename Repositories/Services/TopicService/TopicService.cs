using COMP1640.DTOs;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace COMP1640.Repositories.Services.TopicService
{
    public class TopicService: ITopicRepository
    {
        private readonly DataContext _datacontex;
        public TopicService(DataContext datacontex)
        {
            this._datacontex = datacontex;
        }

        public string CreateTopic(Topic topic)
        {

            _datacontex.Topics.Add(topic);
            _datacontex.SaveChanges();
            return "oke nhes";
        }

        public string DeleteTopic(int id)
        {
            _datacontex.Topics.Remove(_datacontex.Topics.Find(id));
            _datacontex.SaveChanges();
            return " xoaed";
        }

        public IEnumerable<Topic> GetAllTopics()
        {
            return _datacontex.Topics.ToList();
        }

        public List<CurrentTopicsDTO> GetCurrentTopicsDTO(CurrentTopicsDTORequest dto)
        {
            List<CurrentTopicsDTO> list = new List<CurrentTopicsDTO>();
            try
            {
                SqlConnection conn = Conn.Connection();
                SqlCommand cmdRevenue = new SqlCommand("PRO_TopicBaseAcademicAndFalcuty", conn);
                cmdRevenue.CommandType = CommandType.StoredProcedure;
                cmdRevenue.Parameters.AddWithValue("@academicId", dto.AcademicId);
                cmdRevenue.Parameters.AddWithValue("@falcutyId", dto.FalcutyId);
                conn.Open();

                SqlDataReader cmdRdRevenue = cmdRevenue.ExecuteReader();
                while (cmdRdRevenue.Read())
                {
                    CurrentTopicsDTO cr = new()
                    {
                        Id = cmdRdRevenue.GetValue(0).ToString(),
                        Name = cmdRdRevenue.GetValue(1).ToString(),
                        Description = cmdRdRevenue.GetValue(2).ToString(),
                        FalcutyId = cmdRdRevenue.GetValue(3).ToString(),
                        AcademicId = cmdRdRevenue.GetValue(4).ToString(),
                        EntriesDate = cmdRdRevenue.GetValue(5).ToString(),
                        FinalDate = cmdRdRevenue.GetValue(6).ToString(),
                    };
                    list.Add(cr);
                }
                conn.Close();
                return list;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Topic GetTopicById(int id)
        {

            return _datacontex.Topics.Find(id);
        }

        public string UpdateTopic(Topic topic)
        {

            _datacontex.Topics.Update(topic);
            _datacontex.SaveChanges();
            return "thanh_cong";
        }

    }
    
}
