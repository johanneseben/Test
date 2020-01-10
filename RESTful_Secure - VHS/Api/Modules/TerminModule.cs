using Common.Services;
using Nancy;
using Nancy.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;
using Common.Models;
using Nancy.Serialization.JsonNet;
using Nancy.Security;

namespace Api.Modules
{
    public class TerminModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public TerminModule(TerminService terminService)
            : base("/termine")
        {
            Get["/"] = p =>
            {
                var termine= terminService.Get();
                return new JsonResponse(termine, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var termin = terminService.Get(p.id);
                if(termin == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(termin, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Termin post = this.Bind();
                try
                {
                    var result = terminService.Add(post);
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.Created;
            };

            Put["/"] = p =>
            {
                Termin put = this.Bind();
                try
                {
                    var result = terminService.Update(put);
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.OK;
            };

            Delete["/{id}"] = p =>
            {
                try
                {
                    var result = terminService.Delete(p.id);
                    return new JsonResponse(result, new DefaultJsonSerializer());
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
            };
        }
    }
}
