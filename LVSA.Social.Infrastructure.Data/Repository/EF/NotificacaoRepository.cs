using LVSA.Social.Domain;
using LVSA.Social.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Social.Infrastructure.Data.Repository.EF
{
    public class NotificacaoRepository : RepositoryBase<Notificacao>, INotificacaoRepository
    {
    }
}
