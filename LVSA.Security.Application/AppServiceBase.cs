using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain.Interfaces.Services;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.Models;

namespace LVSA.Security.Application
{
    public class AppServiceBase<TViewModel, TEntity, TIService> : IAppServiceBase<TViewModel, TEntity>
        where TViewModel : class
        where TEntity : class
        where TIService : IServiceBase<TEntity>
    {
        protected readonly TIService Service;
        protected bool Filter { get; set; }
        protected Seguranca Seguranca { get; set; }
        public virtual void SetSeguranca(Seguranca seguranca, bool filter = true)
        {
            Seguranca = seguranca;
            Filter = filter;
        }

        public AppServiceBase(TIService service)
        {
            Service = service;
            Filter = true;
        }

        public virtual IEnumerable<TViewModel> Todos()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TViewModel> Filtrar(Expression<Func<TEntity, bool>> predicate)
        {
            Expression<Func<TEntity, bool>> filter = predicate;

            if (Filter && typeof(TEntity).GetProperty("ColigadaId") != null && Seguranca != null && Seguranca.ColigadaId > 0)
            {
                var prop = Expression.Property(predicate.Parameters[0], "ColigadaId");

                var condition = Expression.Equal(prop, Expression.Constant(Seguranca.ColigadaId, prop.Type));
                var lambda = Expression.Lambda<Func<TEntity, bool>>(condition, predicate.Parameters);

                var condition2 = Expression.Equal(prop, Expression.Constant(null, prop.Type));
                var lambda2 = Expression.Lambda<Func<TEntity, bool>>(condition2, predicate.Parameters);

                var expr = Expression.Or(lambda.Body, lambda2.Body);

                filter = Expression.Lambda<Func<TEntity, bool>>(Expression.AndAlso(filter.Body, expr), predicate.Parameters);
            }

            if (Filter && typeof(TEntity).GetProperty("FilialId") != null && Seguranca != null && Seguranca.FilialId > 0)
            {
                var prop = Expression.Property(predicate.Parameters[0], "FilialId");

                var condition = Expression.Equal(prop, Expression.Constant(Seguranca.FilialId, prop.Type));
                var lambda = Expression.Lambda<Func<TEntity, bool>>(condition, predicate.Parameters);

                var condition2 = Expression.Equal(prop, Expression.Constant(null, prop.Type));
                var lambda2 = Expression.Lambda<Func<TEntity, bool>>(condition2, predicate.Parameters);

                var expr = Expression.Or(lambda.Body, lambda2.Body);

                filter = Expression.Lambda<Func<TEntity, bool>>(Expression.AndAlso(filter.Body, expr), predicate.Parameters);
            }

            if (typeof(TEntity).GetProperty("RECDELETEDON") != null)
            {
                var prop = Expression.Property(predicate.Parameters[0], "RECDELETEDON");
                var condition = Expression.Equal(prop, Expression.Constant(null, prop.Type));
                var lambda = Expression.Lambda<Func<TEntity, bool>>(condition, predicate.Parameters);

                filter = Expression.Lambda<Func<TEntity, bool>>(Expression.AndAlso(filter.Body, lambda.Body), predicate.Parameters);
            }

            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TViewModel>>(Service.Find(filter));
        }

        public virtual TViewModel Incluir(TViewModel model)
        {
            TEntity entity = Mapper.Map<TViewModel, TEntity>(model);

            if (Seguranca != null && Seguranca.ColigadaId != null && Seguranca.ColigadaId > 0)
            {
                var prop = typeof(TEntity).GetProperty("ColigadaId");
                if (prop != null && !((short?)prop.GetValue(entity) > 0))
                    prop.SetValue(entity, Seguranca.ColigadaId);
            }

            if (Seguranca != null && Seguranca.FilialId != null && Seguranca.FilialId > 0)
            {
                var prop = typeof(TEntity).GetProperty("FilialId");
                if (prop != null && !((short?)prop.GetValue(entity) > 0))
                    prop.SetValue(entity, Seguranca.FilialId);
            }


            if (Seguranca != null && Seguranca.CODUSUARIO != null && !string.IsNullOrWhiteSpace(Seguranca.CODUSUARIO))
            {
                var prop = typeof(TEntity).GetProperty("RECCREATEDBY");
                if (prop != null)
                    prop.SetValue(entity, Seguranca.CODUSUARIO);
            }

            Service.Add(entity);

            return Mapper.Map<TEntity, TViewModel>(entity);
        }

        public virtual TViewModel Atualizar(TViewModel model)
        {
            TEntity entity = Mapper.Map<TViewModel, TEntity>(model);

            if (Seguranca != null && Seguranca.ColigadaId != null && Seguranca.ColigadaId > 0)
            {
                var prop = typeof(TEntity).GetProperty("ColigadaId");
                if (prop != null && !((short?)prop.GetValue(entity) > 0))
                    prop.SetValue(entity, Seguranca.ColigadaId);
            }

            if (Seguranca != null && Seguranca.FilialId != null && Seguranca.FilialId > 0)
            {
                var prop = typeof(TEntity).GetProperty("FilialId");
                if (prop != null && !((short?)prop.GetValue(entity) > 0))
                    prop.SetValue(entity, Seguranca.FilialId);
            }


            if (Seguranca != null && Seguranca.CODUSUARIO != null && !string.IsNullOrWhiteSpace(Seguranca.CODUSUARIO))
            {
                var prop = typeof(TEntity).GetProperty("RECMODIFIEDBY");
                if (prop != null)
                    prop.SetValue(entity, Seguranca.CODUSUARIO);
            }

            Service.Update(entity);

            return Mapper.Map<TEntity, TViewModel>(entity);
        }

        public virtual void Remover(TViewModel model)
        {
            TEntity entity = Mapper.Map<TViewModel, TEntity>(model);

            Service.Delete(entity);
        }
    }
}
