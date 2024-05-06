using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.BusinessLayer.Concrete
{
    public class TeamMenager : ITeamService
    {
        private readonly ITeamDal _teamDal;

        public TeamMenager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public void TDelete(Team entity)
        {
            _teamDal.Delete(entity);
        }

        public List<Team> TGetAll()
        {
            return _teamDal.GetAll();
        }

        public Team TGetByID(int id)
        {
            return _teamDal.GetByID(id);
        }

        public void TInsert(Team entity)
        {
            _teamDal.Insert(entity);
        }

        public void TUpdate(Team entity)
        {
            _teamDal.Update(entity);
        }
    }
}
