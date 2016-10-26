
using LVSA.Security.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace LVSA.Global.Application.Interfaces
{
    public interface IAppServiceBase<TViewModel, TEntity> : LVSA.Base.Application.Interfaces.IAppServiceBase<TViewModel,TEntity>
        where TViewModel : class
        where TEntity : class
    {
        void SetSeguranca(Seguranca seguranca, bool filter = true);
    }
}
