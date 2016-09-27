
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartGraphy.OnlineOrderingSystem.Core.DTO;

namespace SmartGraphy.OnlineOrderingSystem.Core.BL
{
    public class AbstractBL<T, IdT>
    {
        private EntityManagerDataContext _EntityManager = new EntityManagerDataContext();      

        /// <summary>
        ///     Save All Changes holding by EntityManager
        /// </summary>
        /// <returns>true if transaction complete false otherwise</returns>
        public bool SaveChanges()
        {
            try
            {
                _EntityManager.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                //Logger.Error("AbstractDao", "Error In Save Changes: \n " + e.Message);
                //Logger.Error("AbstractDao", "Error In Save Changes: \n " + e.StackTrace);
                if (null != _EntityManager.Transaction)
                {
                    _EntityManager.Transaction.Rollback();
                }
                return false;
                throw e;
            }
        }


        protected EntityManagerDataContext EntityManager
        {
            get
            {
                if (null == _EntityManager)
                {
                    _EntityManager = new EntityManagerDataContext();
                }
                return _EntityManager;
            }
            set
            {
                _EntityManager = value;
            }
        }
        
    }
}
