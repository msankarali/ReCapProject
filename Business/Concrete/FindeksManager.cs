using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        private readonly IFindeksDal _findeksDal;

        public FindeksManager(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }

        public IResult Add(Findeks findeks)
        {
            _findeksDal.Add(findeks);
            return new SuccessResult();
        }

        public IResult Delete(Findeks findeks)
        {
            _findeksDal.Delete(findeks);
            return new SuccessResult();
        }

        public IDataResult<List<Findeks>> GetAll()
        {
            return new SuccessDataResult<List<Findeks>>(_findeksDal.GetAll());
        }

        public IDataResult<Findeks> GetById(int findeksId)
        {
            return new SuccessDataResult<Findeks>(_findeksDal.Get(f => f.FindeksId == findeksId));
        }

        public IDataResult<int> GetCarFindeks()
        {
            Random random = new Random();
            int result = random.Next(999, 1901);
            return new SuccessDataResult<int>(result);
        }

        public IDataResult<int> GetUserFindeks()
        {
            Random random = new Random();
            int result = random.Next(999, 1901);
            return new SuccessDataResult<int>(result);
        }

        public IResult Update(Findeks findeks)
        {
            _findeksDal.Update(findeks);
            return new SuccessResult();
        }
    }
}
