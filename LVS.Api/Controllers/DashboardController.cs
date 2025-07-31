using LVS.Api.Models;
using LVS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LVS.Api.Controllers
{
    public class DashboardController : ApiController
    {



        private LAFScrapEntities db = new LAFScrapEntities();
        
        //GET: api/--TOTAL DIA ANTERIOR PLANTA
        [Route("api/Dashboard/GetTotalPlanta")]

        public  CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA_Result GetTotalPlanta()
        {
            CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA_Result _item = new CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA_Result();
            List<CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA_Result> total_planta = db.CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA().Select(z => new CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA_Result
            {
                PORCENTAJE = z.PORCENTAJE,
                PRODUCCION_KGS = z.PRODUCCION_KGS,
                PRODUCCION_MTS = z.PRODUCCION_MTS,
                SCRAP_KGS = z.SCRAP_KGS
            }).ToList();


            foreach (CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA_Result item in total_planta)
            {
                _item =  item;
            }

            return _item;

        }



        //GET: api/--TOTAL DIA ANTERIOR PLANTA
        [Route("api/Dashboard/GetTotalPlantaCerradas")]

        public CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA_OP_CERRADAS_Result GetTotalPlantaCerradas()
        {


            CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA_OP_CERRADAS_Result _item = new CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA_OP_CERRADAS_Result();
            List<CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA_OP_CERRADAS_Result> total_planta = db.CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA_OP_CERRADAS().Select(z => new CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA_OP_CERRADAS_Result
            {
                PORCENTAJE = z.PORCENTAJE,
                PRODUCCION_KGS = z.PRODUCCION_KGS,
                PRODUCCION_MTS = z.PRODUCCION_MTS,
                SCRAP_KGS = z.SCRAP_KGS
            }).ToList();


            foreach (CSP_INDICADORES_PORCENTAJE_TOTAL_PLANTA_OP_CERRADAS_Result item in total_planta)
            {
                _item = item;
            }

            return _item;

        }



        //GET: api/--TOTAL DIA ANTERIOR PLANTA
        [Route("api/Dashboard/GetIndicadoresTotalesOp")]

        public List<CSP_INDICADORES_TOTALES_OP_X_MES_Result> GetIndicadoresTotalesOp()
        {
            List<CSP_INDICADORES_TOTALES_OP_X_MES_Result> total_IndicadoresTotalesOp = db.CSP_INDICADORES_TOTALES_OP_X_MES().Select(z => new CSP_INDICADORES_TOTALES_OP_X_MES_Result
            {
                DTPRODUCAO = z.DTPRODUCAO,
                Cerradas = z.Cerradas,
                Todas = z.Todas,
            }).ToList();



            return total_IndicadoresTotalesOp;

        }

        //GET: api/--TOTAL DIA ANTERIOR PLANTA
        [Route("api/Dashboard/GetIndicadoresTotalScrap")]

        public List<CSP_INDICADORES_SCRAP_PRODUCCION_Result> GetIndicadoresTotalScrap()
        {
            List<CSP_INDICADORES_SCRAP_PRODUCCION_Result> total_IndicadoresTotalesOp = db.CSP_INDICADORES_SCRAP_PRODUCCION().Select(z => new CSP_INDICADORES_SCRAP_PRODUCCION_Result
            {
                DTPRODUCAO = z.DTPRODUCAO,
                SCRAP = z.SCRAP,
                PRODUCCION_KGS = z.PRODUCCION_KGS
            }).ToList();



            return total_IndicadoresTotalesOp;

        }


        //GET: api/--TOTAL DIA ANTERIOR PLANTA
        [Route("api/Dashboard/GetImpresionDetalle")]

        public List<CSP_INDICADORES_IMPRESORAS_X_MES_Result> GetImpresionDetalle()
        {
            List<CSP_INDICADORES_IMPRESORAS_X_MES_Result> total_impresion_detalle = db.CSP_INDICADORES_IMPRESORAS_X_MES().Select(z => new CSP_INDICADORES_IMPRESORAS_X_MES_Result
            {
                DTPRODUCAO = z.DTPRODUCAO,
                FISCHER = z.FISCHER,
                HELIOSTAR = z.HELIOSTAR,
                ROTOMEC = z.ROTOMEC,
                ALLSTEIN = z.ALLSTEIN,
            }).ToList();



            return total_impresion_detalle;

        }

        //GET: api/--TOTAL DIA ANTERIOR PLANTA
        [Route("api/Dashboard/GetLaminacionDetalle")]

        public List<CSP_INDICADORES_LAMINADORAS_X_MES_Result> GetLaminacionDetalle()
        {
            List<CSP_INDICADORES_LAMINADORAS_X_MES_Result> total_impresion_detalle = db.CSP_INDICADORES_LAMINADORAS_X_MES().Select(z => new CSP_INDICADORES_LAMINADORAS_X_MES_Result
            {
                DTPRODUCAO = z.DTPRODUCAO,
                LAMINADORA_2 = z.LAMINADORA_2,
                LAMINADORA_3 = z.LAMINADORA_3,
                LAMINADORA_4 = z.LAMINADORA_4,
                LAMINADORA_5 = z.LAMINADORA_5
            }).ToList();



            return total_impresion_detalle;

        }


        [ResponseType(typeof(CSP_REPORTE_EFICIENCIA_X_NUMORDEN_CERRADA_Result))]
        [Route("api/Dashboard/GetReportePorOpCerrada/")]
        
        
        public IHttpActionResult GetReportePorOpCerrada(int op)
        {
            List<CSP_REPORTE_EFICIENCIA_X_NUMORDEN_CERRADA_Result> reporte_op_cerrada = db.CSP_REPORTE_EFICIENCIA_X_NUMORDEN_CERRADA(op).Select(z => new CSP_REPORTE_EFICIENCIA_X_NUMORDEN_CERRADA_Result
            {
                CodAtiv = z.CodAtiv,
                CodRecurso = z.CodRecurso,
                DescripcionOP = z.DescripcionOP,
                FatorPesoProducao = z.FatorPesoProducao,
                KGScrap = z.KGScrap,
                NUMORDEM = z.NUMORDEM,
                QtdProduzidaKg = z.QtdProduzidaKg,
                 QtdProduzidaMts = z.QtdProduzidaMts,
                 incidencia = z.incidencia
            }).ToList();



            return Ok(reporte_op_cerrada);

        }


        [ResponseType(typeof(CSP_INDICADOR_TOTAL_SCRAP_X_OP_Result))]
        [Route("api/Dashboard/GetReportePorOpCerradaTotal/")]


        public IHttpActionResult GetReportePorOpCerradaTotal(string op)
        {
            List<CSP_INDICADOR_TOTAL_SCRAP_X_OP_Result> reporte_op_cerrada_total = db.CSP_INDICADOR_TOTAL_SCRAP_X_OP(op).Select(z => new CSP_INDICADOR_TOTAL_SCRAP_X_OP_Result
            {
                CodAtiv = z.CodAtiv,
                DescripcionOP = z.DescripcionOP,
                NUMORDEM = z.NUMORDEM,
                QtdProduzidaKg = z.QtdProduzidaKg,
                QtdProduzidaMts = z.QtdProduzidaMts,
                IdAtiv = z.IdAtiv,
                KGTOTALSCRAP = z.KGTOTALSCRAP,
                porcentajescrap = z.porcentajescrap
            }).ToList();



            return Ok(reporte_op_cerrada_total);

        }




        [ResponseType(typeof(CSP_REPORTE_EFICIENCIA_X_FECHAS_NUMOREDEN_CERRADAS_Result))]
        [Route("api/Dashboard/GetReportePorFecha/")]


        public IHttpActionResult GetReportePorFecha(string dateDesde, string dateHasta, string tipo)


        {



            DateTime fechaDesde = Convert.ToDateTime(dateDesde);
            DateTime fechaHasta = Convert.ToDateTime(dateHasta);


            List<CSP_REPORTE_EFICIENCIA_X_FECHAS_NUMOREDEN_CERRADAS_Result> reporte_op_fecha = db.CSP_REPORTE_EFICIENCIA_X_FECHAS_NUMOREDEN_CERRADAS(fechaDesde.Date, fechaHasta.Date, tipo).Select(z => new CSP_REPORTE_EFICIENCIA_X_FECHAS_NUMOREDEN_CERRADAS_Result
            {
                 CORTE_N1 = z.CORTE_N1,
                 CORTE_N3 = z.CORTE_N3,
                 CORTE_N2 = z.CORTE_N2,
                 DOYPACK = z.DOYPACK,
                 EMBOSSING = z.EMBOSSING,
                 IMPRESION_F = z.IMPRESION_F,
                 IMPRESION_H = z.IMPRESION_H,
                 LAMINACION_1 = z.LAMINACION_1,
                 LAMINACION_2   = z.LAMINACION_2,
                 LAMINACION_3 = z.LAMINACION_3,
                 MANGAS_COR = z.MANGAS_COR,
                 MANGAS_PEG = z.MANGAS_PEG,
                 MANGAS_REV = z.MANGAS_REV,
                 PLIEGOS_COR = z.PLIEGOS_COR,
                 PLIEGOS_EMB = z.PLIEGOS_EMB,
                 PLIEGOS_TROQ = z.PLIEGOS_TROQ,
                 REVISADO_N1    = z.REVISADO_N1,
                 REVISADO_N2 = z.REVISADO_N2,
                 REVISADO_N3 = z.REVISADO_N3,
                 REVISADO_N4 = z.REVISADO_N4,
                  NUMOP = z.NUMOP,
                  PorcentajeTotalScrap = z.PorcentajeTotalScrap,
                  TotalKgProducidos = z.TotalKgProducidos,
                  TotalScrap = z.TotalScrap



            }).ToList();



            return Ok(reporte_op_fecha);

        }

        [ResponseType(typeof(CSP_REPORTE_ROMANEO_Result))]
        [Route("api/Dashboard/GetReporteRomaneo/")]


        public IHttpActionResult GetReporteRomaneo(int? pNroOf, string pCodProducto, string dateDesde, string dateHasta, int? pTurno, string pTipoRomaneo)
        {



            if (pNroOf == null)
            {
                pNroOf = 0;
            }

            if (pTurno == null)
            {
                pTurno = 0;
            }

            if (String.IsNullOrEmpty(pCodProducto) || pCodProducto == "undefined")
            {
                pCodProducto = "";
            }

            if (String.IsNullOrEmpty(pTipoRomaneo))
            {
                pTipoRomaneo = "";
            }

            DateTime fechaDesde = Convert.ToDateTime(dateDesde);
            DateTime fechaHasta = Convert.ToDateTime(dateHasta + " 11:59:00 PM");


            List<CSP_REPORTE_ROMANEO_Result> reporte_romaneo = db.CSP_REPORTE_ROMANEO(pNroOf,pCodProducto, fechaDesde, fechaHasta,pTurno,pTipoRomaneo).Select(z => new CSP_REPORTE_ROMANEO_Result
            {
                Bobinas = z.Bobinas,
                CantBultos = z.CantBultos,
                CodProducto = z.CodProducto,
                TipoRomaneo = z.TipoRomaneo,
                DescProducto = z.DescProducto,
                Fecha = z.Fecha,
                Legajo = z.Legajo,
                MTS = z.MTS,
                NroPallet = z.NroPallet,
                Obs = z.Obs,
                PesoBruto = z.PesoBruto,
                PesoNeto = z.PesoNeto,
                Unidades = z.Unidades,
                Turno = z.Turno,
                NroOf = z.NroOf,
                IdRomaneo = z.IdRomaneo,
                MTS2 = z.MTS2
              
              
             }).ToList();



            return Ok(reporte_romaneo);

        }


        // DELETE: api/PSSEtiquetas/5
        [ResponseType(typeof(Model.PSSEtiquetas))]
        [Route("api/Dashboard/deleteRomaneo/")]

        public IHttpActionResult deleteRomaneo(int id)
        {
            Model.PSSRomaneo romaneo = db.PSSRomaneo.Where(x=> x.IdRomaneo == id).FirstOrDefault();
            List<PSSRomaneoItems> romaneoitems = db.PSSRomaneoItems.Where(x => x.IdRomaneo == id).ToList();

            if (romaneo == null)
            {
                return NotFound();

            }
            if (romaneoitems.Count() != 0)
            {

                foreach (PSSRomaneoItems romaneoitem in romaneoitems)
                {

                    db.Entry(romaneoitem).State = EntityState.Deleted;


                }


            }



            db.Entry(romaneo).State = EntityState.Deleted;

            db.SaveChanges();

            return Ok();
        }



        //GET: api/--TOTAL DIA ANTERIOR IMPRESION
        [Route("api/Dashboard/GetTotalArea")]

        public CSP_INDICADORES_PORCENTAJE_POR_AREA_Result GetTotalArea()
        {
            CSP_INDICADORES_PORCENTAJE_POR_AREA_Result _item = new CSP_INDICADORES_PORCENTAJE_POR_AREA_Result();
            List<CSP_INDICADORES_PORCENTAJE_POR_AREA_Result> total_area = db.CSP_INDICADORES_PORCENTAJE_POR_AREA(2).Select(z => new CSP_INDICADORES_PORCENTAJE_POR_AREA_Result
            {
                PORCENTAJE = z.PORCENTAJE,
                PRODUCCION_KGS = z.PRODUCCION_KGS,
                PRODUCCION_MTS = z.PRODUCCION_MTS,
                SCRAP_KGS = z.SCRAP_KGS
            }).ToList();


            foreach (CSP_INDICADORES_PORCENTAJE_POR_AREA_Result item in total_area)
            {
                _item = item;
            }

            return _item;

        }


        // GET: api/PSSMaquinasPorOperador/5
        [ResponseType(typeof(CSP_INDICADORES_PORCENTAJE_POR_AREA_Result))]
        [Route("api/Dashboard/GetTotalAreas/")]
        public IHttpActionResult GetTotalAreas(int area)
        {
            CSP_INDICADORES_PORCENTAJE_POR_AREA_Result _item = new CSP_INDICADORES_PORCENTAJE_POR_AREA_Result();
            List<CSP_INDICADORES_PORCENTAJE_POR_AREA_Result> total_area = db.CSP_INDICADORES_PORCENTAJE_POR_AREA(area).Select(z => new CSP_INDICADORES_PORCENTAJE_POR_AREA_Result
            {
                PORCENTAJE = z.PORCENTAJE,
                PRODUCCION_KGS = z.PRODUCCION_KGS,
                PRODUCCION_MTS = z.PRODUCCION_MTS,
                SCRAP_KGS = z.SCRAP_KGS
            }).ToList();


            foreach (CSP_INDICADORES_PORCENTAJE_POR_AREA_Result item in total_area)
            {
                _item = item;
            }

            return Ok(_item);
        }


        // GET: api/PSSMaquinasPorOperador/5
        [ResponseType(typeof(impresion7dias))]
        [Route("api/Dashboard/GetTotalImpresion")]
        public IHttpActionResult GetTotalImpresion()
        {

            List<CSP_METRICS_SCRAP_ULT_7_DIAS_X_AREA_Result> total_impresion = db.CSP_METRICS_SCRAP_ULT_7_DIAS_X_AREA(1).ToList();

            impresion7dias impresion = new impresion7dias();

            decimal totalScrap = 0;
            double totalProducidos = 0;

            decimal incidenciaFischer = 0;
            decimal produccionFischer = 0;
            decimal scrapFischer = 0;

            decimal incidenciaRotomec = 0;
            decimal produccionRotomec = 0;
            decimal scrapRotomec = 0;


            decimal incidenciaHeliostar = 0;
            decimal produccionHeliostar = 0;
            decimal scrapHeliostar = 0;

            decimal incidenciaAllstein = 0;
            decimal produccionAllstein = 0;
            decimal scrapAllstein = 0;

            foreach (CSP_METRICS_SCRAP_ULT_7_DIAS_X_AREA_Result item in total_impresion)
            {
                totalScrap = totalScrap + Convert.ToDecimal(item.SCRAPKG);
                totalProducidos = Convert.ToDouble(totalProducidos + item.PRODUCCION_KGS);

                var fechaactual = item.DTPRODUCAO;
                

                switch (item.CODRECURSO)
                {

                    case "IMP FISCHER2":
                        incidenciaFischer = Convert.ToDecimal(item.INCIDENCIA);
                        produccionFischer = Convert.ToDecimal(item.PRODUCCION_KGS);
                        scrapFischer = Convert.ToDecimal(item.SCRAPKG);
                        break;

                    case "IMP ROTOMEC":
                        incidenciaRotomec = Convert.ToDecimal(item.INCIDENCIA);
                        produccionRotomec = Convert.ToDecimal(item.PRODUCCION_KGS);
                        scrapRotomec = Convert.ToDecimal(item.SCRAPKG);
                        break;

                    case "IMP HELIOSTR":
                        incidenciaHeliostar = Convert.ToDecimal(item.INCIDENCIA);
                        produccionHeliostar = Convert.ToDecimal(item.PRODUCCION_KGS);
                        scrapHeliostar = Convert.ToDecimal(item.SCRAPKG);
                        break;
                    case "IMP ALLSTEIN":
                        incidenciaAllstein = Convert.ToDecimal(item.INCIDENCIA);
                        produccionAllstein = Convert.ToDecimal(item.PRODUCCION_KGS);
                        scrapAllstein = Convert.ToDecimal(item.SCRAPKG);
                        break;
                }

            }


                impresion.totalScrap = totalScrap;
                impresion.totalProducidos = totalProducidos;

                impresion.incidenciaFischer = incidenciaFischer;
                impresion.produccionFischer = produccionFischer;
                impresion.scrapFischer = scrapFischer;


                impresion.incidenciaRotomec = incidenciaRotomec;
                impresion.produccionRotomec = produccionRotomec;
                impresion.scrapRotomec = scrapRotomec;

                impresion.incidenciaHeliostar = incidenciaHeliostar;
                impresion.produccionHeliostar = produccionHeliostar;
                impresion.scrapHeliostar = scrapHeliostar;


                impresion.incidenciaAllstein = incidenciaAllstein;
                impresion.produccionAllstein = produccionAllstein;
                impresion.scrapAllstein = scrapAllstein;













            return Ok(impresion);
        }





        // GET: api/PSSMaquinasPorOperador/5
        [ResponseType(typeof(impresion7dias))]
        [Route("api/Dashboard/GetTotalLaminacion")]
        public IHttpActionResult GetTotalLaminacion()
        {
            List<CSP_METRICS_SCRAP_ULT_7_DIAS_X_AREA_Result> total_laminacion = db.CSP_METRICS_SCRAP_ULT_7_DIAS_X_AREA(6).ToList();

            laminacion7dias laminacion = new laminacion7dias();
            List<listadodetallemaquina> listadodetallemaquina = new List<listadodetallemaquina>();
            
            decimal totalScrap = 0;
            double totalProducidos = 0;

            
            foreach (CSP_METRICS_SCRAP_ULT_7_DIAS_X_AREA_Result item in total_laminacion)
            {
                totalScrap = totalScrap + Convert.ToDecimal(item.SCRAPKG);
                totalProducidos = Convert.ToDouble(totalProducidos + item.PRODUCCION_KGS);

                var fechaactual = item.DTPRODUCAO;

                listadodetallemaquina detallemaquina = new listadodetallemaquina();
                detallemaquina.nombre = item.CODRECURSO;
                detallemaquina.incidencia = Convert.ToDecimal(item.INCIDENCIA);
                detallemaquina.produccion = Convert.ToDecimal(item.PRODUCCION_KGS);
                detallemaquina.scrap = Convert.ToDecimal(item.SCRAPKG);

                listadodetallemaquina.Add(detallemaquina);
            }


            laminacion.totalScrap = totalScrap;
            laminacion.totalProducidos = totalProducidos;
            laminacion.listadodetallemaquina = listadodetallemaquina;


















            return Ok(laminacion);
        }




    }
}
