using MeetGroupApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;

namespace MeetGroupApp.Services
{
    public class ReuniaoService : Controller
    {
        private MeetGroupAppContext db = new MeetGroupAppContext();

        public Reuniao VerificacaoDeSala(Reuniao reuniao)
        {
            var context = db.Reuniaos.ToList();
            var Verificador = context.FindAll(x => x.DataInicio == reuniao.DataInicio);


            var Sala1Ocupada = Verificador.FindAll(x => x.NumeroSala == 1 && (x.HoraFim <= reuniao.HoraInicio || x.HoraInicio >= reuniao.HoraInicio || reuniao.HoraFim >= x.HoraFim));
            var Sala2Ocupada = Verificador.FindAll(x => x.NumeroSala == 2 && (x.HoraFim <= reuniao.HoraInicio || x.HoraInicio >= reuniao.HoraInicio || reuniao.HoraFim >= x.HoraFim));
            var Sala3Ocupada = Verificador.FindAll(x => x.NumeroSala == 3 && (x.HoraFim <= reuniao.HoraInicio || x.HoraInicio >= reuniao.HoraInicio || reuniao.HoraFim >= x.HoraFim));
            var Sala4Ocupada = Verificador.FindAll(x => x.NumeroSala == 4 && (x.HoraFim <= reuniao.HoraInicio || x.HoraInicio >= reuniao.HoraInicio || reuniao.HoraFim >= x.HoraFim));
            var Sala5Ocupada = Verificador.FindAll(x => x.NumeroSala == 5 && (x.HoraFim <= reuniao.HoraInicio || x.HoraInicio >= reuniao.HoraInicio || reuniao.HoraFim >= x.HoraFim));
            var Sala6Ocupada = Verificador.FindAll(x => x.NumeroSala == 6 && (x.HoraFim <= reuniao.HoraInicio || x.HoraInicio >= reuniao.HoraInicio || reuniao.HoraFim >= x.HoraFim));
            var Sala7Ocupada = Verificador.FindAll(x => x.NumeroSala == 7 && (x.HoraFim <= reuniao.HoraInicio || x.HoraInicio >= reuniao.HoraInicio || reuniao.HoraFim >= x.HoraFim));
            var Sala8Ocupada = Verificador.FindAll(x => x.NumeroSala == 8 && (x.HoraFim <= reuniao.HoraInicio || x.HoraInicio >= reuniao.HoraInicio || reuniao.HoraFim >= x.HoraFim));
            var Sala9Ocupada = Verificador.FindAll(x => x.NumeroSala == 9 && (x.HoraFim <= reuniao.HoraInicio || x.HoraInicio >= reuniao.HoraInicio || reuniao.HoraFim >= x.HoraFim));
            var Sala10Ocupada = Verificador.FindAll(x => x.NumeroSala == 10 && (x.HoraFim <= reuniao.HoraInicio || x.HoraInicio >= reuniao.HoraInicio || reuniao.HoraFim >= x.HoraFim));
            var Sala11Ocupada = Verificador.FindAll(x => x.NumeroSala == 11 && (x.HoraFim <= reuniao.HoraInicio || x.HoraInicio >= reuniao.HoraInicio || reuniao.HoraFim >= x.HoraFim));
            var Sala12Ocupada = Verificador.FindAll(x => x.NumeroSala == 12 && (x.HoraFim <= reuniao.HoraInicio || x.HoraInicio >= reuniao.HoraInicio || reuniao.HoraFim >= x.HoraFim));

            if (reuniao.Pessoas <= 10 && reuniao.Pessoas > 3 && reuniao.Televisor.Equals(true) && reuniao.Computador.Equals(true) && reuniao.Internet.Equals(true))
            {
                if (Sala1Ocupada.Count == 0)
                {
                    reuniao.NumeroSala = 1;
                }
                else if (Sala2Ocupada.Count == 0)
                {
                    reuniao.NumeroSala = 2;
                }
                else if (Sala3Ocupada.Count == 0)
                {
                    reuniao.NumeroSala = 3;
                }
                else if (Sala4Ocupada.Count == 0)
                {
                    reuniao.NumeroSala = 4;
                }
                else if (Sala5Ocupada.Count == 0)
                {
                    reuniao.NumeroSala = 5;
                }
                else
                    reuniao.NumeroSala = 0;

            }
            else if (reuniao.Pessoas <= 10 && reuniao.Televisor.Equals(false) && reuniao.Computador.Equals(false) && reuniao.Internet.Equals(true))
            {
                if (Sala6Ocupada.Count == 0)
                {
                    reuniao.NumeroSala = 6;
                }
                else if (Sala7Ocupada.Count == 0)
                {
                    reuniao.NumeroSala = 7;
                }
                else
                {
                    reuniao.NumeroSala = 0;
                }

            }
            else if (reuniao.Pessoas <= 3 && reuniao.Televisor.Equals(true) && reuniao.Computador.Equals(true) && reuniao.Internet.Equals(true))
            {
                if (Sala8Ocupada.Count == 0)
                {
                    reuniao.NumeroSala = 8;
                }
                else if (Sala9Ocupada.Count == 0)
                {
                    reuniao.NumeroSala = 9;
                }
                else if (Sala10Ocupada.Count == 0)
                {
                    reuniao.NumeroSala = 10;
                }
                else
                {
                    reuniao.NumeroSala = 0;
                }
            }
            else if (reuniao.Pessoas <= 20 && reuniao.Televisor.Equals(false) && reuniao.Computador.Equals(false) && reuniao.Internet.Equals(false))
            {
                if (Sala11Ocupada.Count == 0)
                {
                    reuniao.NumeroSala = 11;
                }
                else if(Sala12Ocupada.Count == 0)
                {
                    reuniao.NumeroSala = 11;
                }
                else
                {
                    reuniao.NumeroSala = 0;
                }
            }
            return reuniao;

        }
    }
}