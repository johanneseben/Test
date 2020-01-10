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
    public class MitgliedschaftModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public MitgliedschaftModule(MitgliedschaftService mitgliedschaftService)
            : base("/mitgliedschaften")
        {
            Get["/"] = p =>
            {
                var mitgliedschaften= mitgliedschaftService.Get();
                return new JsonResponse(mitgliedschaften, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var mitgliedschaft = mitgliedschaftService.Get(p.id);
                if(mitgliedschaft == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(mitgliedschaft, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Mitgliedschaft post = this.Bind();
                try
                {
                    var result = mitgliedschaftService.Add(post);
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
                Mitgliedschaft put = this.Bind();
                try
                {
                    var result = mitgliedschaftService.Update(put);
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
                    var result = mitgliedschaftService.Delete(p.id);
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
