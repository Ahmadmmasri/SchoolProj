using SchoolProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Reposotries
{
    public interface IRegestrationDetailsInfo
    {
        public List<RegestrationDetails> GetAll();
    }
}
