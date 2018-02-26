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

            if (reuniao.Pessoas <= 10 && reuniao.Pessoas > 3 && reuniao.Televisor.Equals(true) && reuniao.Computador.Equals(true) && reuniao.Internet.Equals(true))
            {
                if (Verificador.Any(x => x.NumeroSala == 1))
                {
                    if (Verificador.Any(x => x.HoraInicio >= reuniao.HoraInicio && reuniao.HoraInicio <= x.HoraFim))
                    {
                        reuniao.NumeroSala = 2;
                    }
                    else
                        reuniao.NumeroSala = 1;
                }
                else if (Verificador.Any(x => x.NumeroSala == 2))
                {
                    if (Verificador.Any(x => x.HoraInicio >= reuniao.HoraInicio && reuniao.HoraInicio <= x.HoraFim))
                    {
                        reuniao.NumeroSala = 3;
                    }
                    else
                        reuniao.NumeroSala = 2;
                }
                else if (Verificador.Any(x => x.NumeroSala == 3))
                {
                    if (Verificador.Any(x => x.HoraInicio >= reuniao.HoraInicio && reuniao.HoraInicio <= x.HoraFim))
                    {
                        reuniao.NumeroSala = 4;
                    }
                    else
                        reuniao.NumeroSala = 3;
                }
                else if (Verificador.Any(x => x.NumeroSala == 4))
                {
                    if (Verificador.Any(x => x.HoraInicio >= reuniao.HoraInicio && reuniao.HoraInicio <= x.HoraFim))
                    {
                        reuniao.NumeroSala = 5;
                    }
                    reuniao.NumeroSala = 4;
                }

                else
                {
                    reuniao.NumeroSala = 1;
                }
            }
            else
                if (reuniao.Pessoas <= 10 && reuniao.Televisor.Equals(false) && reuniao.Computador.Equals(false) && reuniao.Internet.Equals(true))
            {
                if (Verificador.Any(x => x.NumeroSala == 6))
                {
                    if (Verificador.Any(x => x.HoraInicio >= reuniao.HoraInicio && reuniao.HoraInicio <= x.HoraFim))
                    {
                        reuniao.NumeroSala = 7;
                    }
                    else
                        reuniao.NumeroSala = 6;
                }
                else
                    reuniao.NumeroSala = 6;
            }
            else
                if (reuniao.Pessoas <= 3 && reuniao.Televisor.Equals(true) && reuniao.Computador.Equals(true) && reuniao.Internet.Equals(true))
            {
                if (Verificador.Any(x => x.NumeroSala == 8))
                {
                    if (Verificador.Any(x => x.HoraInicio >= reuniao.HoraInicio && reuniao.HoraInicio <= x.HoraFim))
                    {
                        reuniao.NumeroSala = 9;
                    }
                    else
                        reuniao.NumeroSala = 8;
                }
                else if (Verificador.Any(x => x.NumeroSala == 9))
                {
                    if (Verificador.Any(x => x.HoraInicio >= reuniao.HoraInicio && reuniao.HoraInicio <= x.HoraFim))
                    {
                        reuniao.NumeroSala = 10;
                    }
                    else
                        reuniao.NumeroSala = 9;
                }
                else
                    reuniao.NumeroSala = 8;
            }
            else
                if (reuniao.Pessoas <= 20 && reuniao.Televisor.Equals(false) && reuniao.Computador.Equals(false) && reuniao.Internet.Equals(false))
            {
                if (Verificador.Any(x => x.NumeroSala == 11))
                {
                    if (Verificador.Any(x => x.HoraInicio >= reuniao.HoraInicio && reuniao.HoraInicio <= x.HoraFim))
                    {
                        reuniao.NumeroSala = 12;
                    }
                    else
                        reuniao.NumeroSala = 11;
                }
                else
                    reuniao.NumeroSala = 11;
            }
            return reuniao;

        }
    }
}