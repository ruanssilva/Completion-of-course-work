using LVSA.Base.Domain.Services;
using LVSA.Social.Domain.Interfaces.Repository;
using LVSA.Social.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Social.Domain.Services
{
    public class NotificacaoService : ServiceBase<Notificacao>, INotificacaoService
    {
        public NotificacaoService(INotificacaoRepository notificacaoRepository)
            : base(notificacaoRepository)
        {

        }
    }
}
