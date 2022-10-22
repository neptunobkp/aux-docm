SET IDENTITY_INSERT [dbo].[Aplicaciones] ON 
GO
INSERT [dbo].[Aplicaciones] ([Id], [Nombre]) VALUES (1, N'Salud')
GO
SET IDENTITY_INSERT [dbo].[Aplicaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Grupos] ON 
GO
INSERT [dbo].[Grupos] ([Id], [AplicacionId], [Nombre], [Codigo]) VALUES (1, 1, N'Carta de garantía', N'CARTA_GARANTIA')
GO
INSERT [dbo].[Grupos] ([Id], [AplicacionId], [Nombre], [Codigo]) VALUES (2, 1, N'Reembolso', N'Reembolso')
GO
SET IDENTITY_INSERT [dbo].[Grupos] OFF
GO
SET IDENTITY_INSERT [dbo].[PdfTemplates] ON 
GO
INSERT [dbo].[PdfTemplates] ([Id], [GrupoId], [Codigo]) VALUES (1, 1, N'Carta_Garantia_G')
GO
INSERT [dbo].[PdfTemplates] ([Id], [GrupoId], [Codigo]) VALUES (3, 1, N'Carta_Garantia_C')
GO
SET IDENTITY_INSERT [dbo].[PdfTemplates] OFF
GO
SET IDENTITY_INSERT [dbo].[EmailTemplates] ON 
GO
INSERT [dbo].[EmailTemplates] ([Id], [Codigo], [GrupoId], [Para], [ConCopia], [ConCopiaOculta]) VALUES (1, N'GENERAL', 1, NULL, N'pruebas@pulse-it.cl', N'jose@pulse-it.cl')
GO
INSERT [dbo].[EmailTemplates] ([Id], [Codigo], [GrupoId], [Para], [ConCopia], [ConCopiaOculta]) VALUES (2, N'CHUBB', 1, NULL, N'pruebas@pulse-it.cl', N'jose@pulse-it.cl')
GO
INSERT [dbo].[EmailTemplates] ([Id], [Codigo], [GrupoId], [Para], [ConCopia], [ConCopiaOculta]) VALUES (3, N'GENERAL', 2, NULL, N'pruebas@pulse-it.cl', N'jose@pulse-it.cl')
GO
SET IDENTITY_INSERT [dbo].[EmailTemplates] OFF
GO
INSERT [dbo].[EmailPdfTemplate] ([EmailTemplateId], [PdfTemplateId]) VALUES (1, 1)
GO
INSERT [dbo].[EmailPdfTemplate] ([EmailTemplateId], [PdfTemplateId]) VALUES (2, 3)
GO
SET IDENTITY_INSERT [dbo].[MasterTemplateData] ON 
GO
INSERT [dbo].[MasterTemplateData] ([Id], [Body], [Codigo]) VALUES (1, N'<html>
    <head>
        <meta content="text/html; charset=utf-8" http-equiv="Content-Type">
        <style>
            .invoice-box {
    max-width: 800px;
    margin: auto;
    padding: 5px;
    border: 1px solid #eee;
    box-shadow: 0 0 10px rgba(0, 0, 0, .15);
    font-size: 10px;
    line-height: 18px;
    font-family: ''Helvetica Neue'', ''Helvetica'', Helvetica, Arial, sans-serif;
    color: #555;
}
.invoice-box table {
    width: 100%;
    line-height: inherit;
    text-align: left;
}
.invoice-box table td {
    padding: 5px;
    vertical-align: top;
}
.invoice-box table td h2 {
   color: #FF4612;
}
.invoice-box  table tr td:nth-child(2) {
    text-align: left;
}

.invoice-box  table tr td:nth-child(1) {
    text-align: left;
}

.invoice-box table tr.top table td {
    padding-bottom: 10px;
}
.invoice-box table tr.top table td.title {
    font-size: 45px;
    line-height: 45px;
    color: #333;
}
.invoice-box table tr.information td {
   font-size: 14px;
}

.invoice-box table tr.heading td {
    background: #eee;
    border-bottom: 1px solid #ddd;
    font-weight: bold;
    color: #FF4612;
     padding-top: 10px;
}

.invoice-box table tr.details td {
    padding-bottom:20px;
}
.invoice-box table tr.item td {
    border-bottom: 1px solid #eee;
}

.invoice-box table tr.item td p {
    text-align: justify;
}

.invoice-box table tr.subitem td p {
     font-size: 10px;
}

.invoice-box table tr.item.last td {
    border-bottom: none;
}
.invoice-box table tr.total td:nth-child(2) {
    border-top: 2px solid #eee;
    font-weight: bold;
}

@media only screen and (max-width: 600px) {
    .invoice-box table tr.top table td {
        width: 100%;
        display: block;
        text-align: center;
    }
    .invoice-box table tr.information table td {
        width: 100%;
        display: block;
        text-align: center;
    }
}
        </style>
    </head>
<body>
   #Contenido#
</body>
</html>', N'PdfBase1')
GO
INSERT [dbo].[MasterTemplateData] ([Id], [Body], [Codigo]) VALUES (2, N'<!doctype html>
<html>

<head>
    <meta name="viewport" content="width=device-width" />
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Auxilia email</title>
    <style>
        img {
            border: none;
            -ms-interpolation-mode: bicubic;
            max-width: 100%;
        }
        
        body {
            background-color: #f6f6f6;
            font-family: sans-serif;
            -webkit-font-smoothing: antialiased;
            font-size: 14px;
            line-height: 1.4;
            margin: 0;
            padding: 0;
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%;
        }
        
        table {
            border-collapse: separate;
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
            width: 100%;
        }
        
        table td {
            font-family: sans-serif;
            font-size: 14px;
            vertical-align: top;
        }
        
        .body {
            background-color: #f6f6f6;
            width: 100%;
        }
        
        .container {
            display: block;
            Margin: 0 auto !important;
            max-width: 580px;
            padding: 10px;
            width: 580px;
        }
        
        .content {
            box-sizing: border-box;
            display: block;
            Margin: 0 auto;
            max-width: 580px;
            padding: 10px;
        }
        
        .main {
            background: #ffffff;
            border-radius: 3px;
            width: 100%;
        }
        
        .wrapper {
            box-sizing: border-box;
            padding: 20px;
        }
        
        .content-block {
            padding-bottom: 10px;
            padding-top: 10px;
        }
        
        .footer {
            clear: both;
            Margin-top: 10px;
            text-align: center;
            width: 100%;
        }
        
        .footer td,
        .footer p,
        .footer span,
        .footer a {
            color: #999999;
            font-size: 12px;
            text-align: center;
        }
        
        h1,
        h2,
        h3,
        h4 {
            color: #000000;
            font-family: sans-serif;
            font-weight: 400;
            line-height: 1.4;
            margin: 0;
            Margin-bottom: 30px;
        }
        
        h1 {
            font-size: 35px;
            font-weight: 300;
            text-align: center;
            text-transform: capitalize;
        }
        
        p,
        ul,
        ol {
            font-family: sans-serif;
            font-size: 14px;
            font-weight: normal;
            margin: 0;
            Margin-bottom: 15px;
        }
        
        p li,
        ul li,
        ol li {
            list-style-position: inside;
            margin-left: 5px;
        }
        
        a {
            color: #3498db;
            text-decoration: underline;
        }
        
        .last {
            margin-bottom: 0;
        }
        
        .first {
            margin-top: 0;
        }
        
        .align-center {
            text-align: center;
        }
        
        .align-right {
            text-align: right;
        }
        
        .align-left {
            text-align: left;
        }
        
        .clear {
            clear: both;
        }
        
        .mt0 {
            margin-top: 0;
        }
        
        .mb0 {
            margin-bottom: 0;
        }
        
        .preheader {
            color: transparent;
            display: none;
            height: 0;
            max-height: 0;
            max-width: 0;
            opacity: 0;
            overflow: hidden;
            mso-hide: all;
            visibility: hidden;
            width: 0;
        }
        
        .powered-by a {
            text-decoration: none;
        }
        
        hr {
            border: 0;
            border-bottom: 1px solid #f6f6f6;
            Margin: 20px 0;
        }
        
        @media only screen and (max-width: 620px) {
            table[class=body] h1 {
                font-size: 28px !important;
                margin-bottom: 10px !important;
            }
            table[class=body] p,
            table[class=body] ul,
            table[class=body] ol,
            table[class=body] td,
            table[class=body] span,
            table[class=body] a {
                font-size: 16px !important;
            }
            table[class=body] .wrapper,
            table[class=body] .article {
                padding: 10px !important;
            }
            table[class=body] .content {
                padding: 0 !important;
            }
            table[class=body] .container {
                padding: 0 !important;
                width: 100% !important;
            }
            table[class=body] .main {
                border-left-width: 0 !important;
                border-radius: 0 !important;
                border-right-width: 0 !important;
            }
            table[class=body] .btn table {
                width: 100% !important;
            }
            table[class=body] .btn a {
                width: 100% !important;
            }
            table[class=body] .img-responsive {
                height: auto !important;
                max-width: 100% !important;
                width: auto !important;
            }
        }
        
        @media all {
            .ExternalClass {
                width: 100%;
            }
            .ExternalClass,
            .ExternalClass p,
            .ExternalClass span,
            .ExternalClass font,
            .ExternalClass td,
            .ExternalClass div {
                line-height: 100%;
            }
            .apple-link a {
                color: inherit !important;
                font-family: inherit !important;
                font-size: inherit !important;
                font-weight: inherit !important;
                line-height: inherit !important;
                text-decoration: none !important;
            }
            .btn-primary table td:hover {
                background-color: #34495e !important;
            }
            .btn-primary a:hover {
                background-color: #34495e !important;
                border-color: #34495e !important;
            }
        }
    </style>
</head>

<body class="">
    #Contenido#
</body>

</html>', N'EmailBase1')
GO
SET IDENTITY_INSERT [dbo].[MasterTemplateData] OFF
GO
SET IDENTITY_INSERT [dbo].[PdfTemplateDataVersion] ON 
GO
INSERT [dbo].[PdfTemplateDataVersion] ([Id], [Body], [Draft]) VALUES (1, N'<div class="invoice-box">
        <table cellpadding="0" cellspacing="0">
            <tr class="top">
                <td colspan="4">
                    <table>
                        <tr>
                            <td class="title">
                                <img src="http://www.auxilia.cc/img/auxilia.png" alt="l" width="60px" />
                            </td>
                            <td style="text-align:left">
                               <h2> CARTA DE GARANTÍA </h1>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
             <tr class="information">
                <td width="10%">
                    Para
                </td>
                <td  align  ="left">
                    : {{NombreProveedor}}
                </td>
                <td width="10%">
                    De
                </td>
                <td width="30%">
                    : Auxilia Asistencia S.A.
                </td>
            </tr>
            <tr class="information">
  
                <td>
                    Área
                </td>
                <td>
                    : Operaciones
                </td>
                 <td>Teléfono</td>
                <td>: +56 2 431 1210</td>
            </tr>
            <tr class="information">
                <td>
                    Asunto 
                </td>
                <td>
                    : Garantía de gastos
                </td>
                <td>
                    Área
                </td>
                <td>
                    : Operaciones
                </td>
              
              <tr class="information">
                  <td></td>
                  <td></td>
                  <td>
                      Fecha
                  </td>
                  <td>
                      :{{Fecha}}
                  </td>
              </tr>
        
            <tr class="heading ">
                <td colspan="4">
                    Referencia:  {{CodigoExpediente}}  {{NombrePaciente}}
                </td>
            </tr>

            <tr class="item information">
                <td colspan="5">
                    <p>
                        Garantizamos atención médica para
                        #TipoAsunto, con un tope inicial 
                        de cobertura de #Monto #Divisa. 
                        En caso de ser necesaria la realización de 
                        algún procedimiento médico adicional, 
                        o tomar a cargo exámenes complementarios, 
                        les solicitamos expresamente aviso previo 
                        para autorizar y garantizar dichos procedimientos.
                    </p>
                </td>
            </tr>
            <tr class="information">
                <td>
                    Nombre
                </td>
                <td>
                   : {{NombrePaciente}}
                </td>
            </tr>
             <tr class="information">
                <td>
                    Rut/Pasaporte
                </td>
                <td>
                   : 
                </td>
            </tr>
            
            <tr class="information">
                <td colspan="2">
                    Fecha Nacimiento
                     : {{FechaNacimiento}}
                </td>
            </tr>
               
                <tr class="information">
                <td>
                    Dirección
                </td>
                <td colspan="3">
                   : {{DireccionPaciente}}
                </td>
            </tr>
            
            <tr class="information">
                 <td>
                    País
                </td>
                <td>
                   : {{PaisPaciente}}
                </td>
            </tr>
            
             <tr class="information">
                <td>
                    Teléfono
                </td>
                <td>
                    : {{TelefonoPaciente}}
                </td>
            </tr>
            <tr class="information">
                <td>
                    Celular
                </td>
                <td>
                    : {{CelularPaciente}}
                </td>
            </tr>
             
            <tr class="heading ">
                <td colspan="4">
                    Datos Facturación
                </td>
            </tr>
                <tr class="information">
                <td>
                    Nombre
                </td>
                <td>
                   : Auxilia Club Asistencia S.A.
                </td>
            </tr>
             <tr class="information">
                <td>
                    Rut
                </td>
                <td colspan="3">
                   : 77.078.150-7
                </td>
            </tr>
                <tr class="information">
                <td>
                    Giro
                </td>
                <td colspan="3">
                   : Prestación De Servicios De Asistencia A Personas Y Empresas
                </td>
            </tr>
            <tr class="information">
                <td>
                    Dirección
                </td>
                <td colspan="3" >
                   : Las Urbinas 68, Providencia. Santiago de Chile
                </td>
            </tr>
            
            <tr class="information">
                <td>
                    Teléfono
                </td>
                <td>
                  : +56 2 431 1210
                </td>
            </tr>
               
             <tr class="item information">
                <td colspan="4">
                    <p>
                        Finalmente quedamos a la espera del reporte médico y de los costos asociados a dicha atención.
                        Esperando que esta información sea de utilidad,
                        </br>
                        Atentamente,
                    </p>
                </td>
            </tr>
            <tr>
               <td colspan="4">
                   <table>
                           <tr>
                                <td width="60px">
                                    <img src="http://www.auxilia.cc/img/auxilia.png" alt="l" width="60px" />
                                </td>
                                <td colspan="3">
                                    {{NombreEjecutivo}} </br>
                                   E-mail:asistenciamedica@auxilia.cl</br>
                                    (+56) 2 431 1210
                                </td>
                           </tr>
                       
                   </table>
               </td>
            </tr>
              <tr class="heading ">
                <td colspan="4">
                   Importante:
                </td>
            </tr>
             <tr class="subitem">
                <td colspan="4">
                    <p>
                      Auxilia Club Asistencia 
                      informa que cualquier costo adicional al tope señalado expresamente en este documento de primera garantía, no podrá ser cobrado o facturado bajo ninguna circunstancia a nuestra compañía, si no existe autorización previa por escrito (fax o email) de dicho costo adicional a la primera garantía.
                      Auxilia Club Asistencia 
                      sólo realiza garantías de 
                      pagos en forma escrita en 
                      modalidad de email y/o fax y
                      nunca vía telefónica. 
                      Si no existe documentación
                      sobre dichas garantías, 
                      Auxilia Club Asistencia
                      no asumirá bajo ninguna circunstancia pagos 
                      adicionales de cualquier tipo. 
                    </p>
                </td>
            </tr>
        </table>
    </div>', 0)
GO
SET IDENTITY_INSERT [dbo].[PdfTemplateDataVersion] OFF
GO
SET IDENTITY_INSERT [dbo].[PdfTemplateData] ON 
GO
INSERT [dbo].[PdfTemplateData] ([Id], [Body], [Idioma], [PdfTemplateId], [PdfTemplateDataVersionId], [MasterTemplateDataId]) VALUES (1, N'<div class="invoice-box">
        <table cellpadding="0" cellspacing="0">
            <tr class="top">
                <td colspan="4">
                    <table>
                        <tr>
                            <td class="title">
                                <img src="http://www.auxilia.cc/img/auxilia.png" alt="l" width="60px" />
                            </td>
                            <td style="text-align:left">
                               <h2> CARTA DE GARANTÍA </h1>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
             <tr class="information">
                <td width="10%">
                    Para
                </td>
                <td  align  ="left">
                    : {{NombreProveedor}}
                </td>
                <td width="10%">
                    De
                </td>
                <td width="30%">
                    : Auxilia Asistencia S.A.
                </td>
            </tr>
            <tr class="information">
  
                <td>
                    Área
                </td>
                <td>
                    : Operaciones
                </td>
                 <td>Teléfono</td>
                <td>: +56 2 431 1210</td>
            </tr>
            <tr class="information">
                <td>
                    Asunto 
                </td>
                <td>
                    : Garantía de gastos
                </td>
                <td>
                    Área
                </td>
                <td>
                    : Operaciones
                </td>
              
              <tr class="information">
                  <td></td>
                  <td></td>
                  <td>
                      Fecha
                  </td>
                  <td>
                      :{{Fecha}}
                  </td>
              </tr>
        
            <tr class="heading ">
                <td colspan="4">
                    Referencia:  {{CodigoExpediente}}  {{NombrePaciente}}
                </td>
            </tr>

            <tr class="item information">
                <td colspan="5">
                    <p>
                        Garantizamos atención médica para
                        {{TipoAsunto}}, con un tope inicial 
                        de cobertura de {{Monto}} . 
                        En caso de ser necesaria la realización de 
                        algún procedimiento médico adicional, 
                        o tomar a cargo exámenes complementarios, 
                        les solicitamos expresamente aviso previo 
                        para autorizar y garantizar dichos procedimientos.
                    </p>
                </td>
            </tr>
            <tr class="information">
                <td>
                    Nombre
                </td>
                <td>
                   : {{NombrePaciente}}
                </td>
            </tr>
             <tr class="information">
                <td>
                    Rut/Pasaporte
                </td>
                <td>
                   : 
                </td>
            </tr>
            
            <tr class="information">
                <td colspan="2">
                    Fecha Nacimiento
                     : {{FechaNacimiento}}
                </td>
            </tr>
               
                <tr class="information">
                <td>
                    Dirección
                </td>
                <td colspan="3">
                   : {{DireccionPaciente}}
                </td>
            </tr>
            
            <tr class="information">
                 <td>
                    País
                </td>
                <td>
                   : {{PaisPaciente}}
                </td>
            </tr>
            
             <tr class="information">
                <td>
                    Teléfono
                </td>
                <td>
                    : {{TelefonoPaciente}}
                </td>
            </tr>
            <tr class="information">
                <td>
                    Celular
                </td>
                <td>
                    : {{CelularPaciente}}
                </td>
            </tr>
             
            <tr class="heading ">
                <td colspan="4">
                    Datos Facturación
                </td>
            </tr>
                <tr class="information">
                <td>
                    Nombre
                </td>
                <td>
                   : Auxilia Club Asistencia S.A.
                </td>
            </tr>
             <tr class="information">
                <td>
                    Rut
                </td>
                <td colspan="3">
                   : 77.078.150-7
                </td>
            </tr>
                <tr class="information">
                <td>
                    Giro
                </td>
                <td colspan="3">
                   : Prestación De Servicios De Asistencia A Personas Y Empresas
                </td>
            </tr>
            <tr class="information">
                <td>
                    Dirección
                </td>
                <td colspan="3" >
                   : Las Urbinas 68, Providencia. Santiago de Chile
                </td>
            </tr>
            
            <tr class="information">
                <td>
                    Teléfono
                </td>
                <td>
                  : +56 2 431 1210
                </td>
            </tr>
               
             <tr class="item information">
                <td colspan="4">
                    <p>
                        Finalmente quedamos a la espera del reporte médico y de los costos asociados a dicha atención.
                        Esperando que esta información sea de utilidad,
                        </br>
                        Atentamente,
                    </p>
                </td>
            </tr>
            <tr>
               <td colspan="4">
                   <table>
                           <tr>
                                <td width="60px">
                                    <img src="http://www.auxilia.cc/img/auxilia.png" alt="l" width="60px" />
                                </td>
                                <td colspan="3">
                                    {{NombreEjecutivo}} </br>
                                   E-mail:asistenciamedica@auxilia.cl</br>
                                    (+56) 2 431 1210
                                </td>
                           </tr>
                       
                   </table>
               </td>
            </tr>
              <tr class="heading ">
                <td colspan="4">
                   Importante:
                </td>
            </tr>
             <tr class="subitem">
                <td colspan="4">
                    <p>
                      Auxilia Club Asistencia 
                      informa que cualquier costo adicional al tope señalado expresamente en este documento de primera garantía, no podrá ser cobrado o facturado bajo ninguna circunstancia a nuestra compañía, si no existe autorización previa por escrito (fax o email) de dicho costo adicional a la primera garantía.
                      Auxilia Club Asistencia 
                      sólo realiza garantías de 
                      pagos en forma escrita en 
                      modalidad de email y/o fax y
                      nunca vía telefónica. 
                      Si no existe documentación
                      sobre dichas garantías, 
                      Auxilia Club Asistencia
                      no asumirá bajo ninguna circunstancia pagos 
                      adicionales de cualquier tipo. 
                    </p>
                </td>
            </tr>
        </table>
    </div>', 0, 1, 1, 1)
GO
INSERT [dbo].[PdfTemplateData] ([Id], [Body], [Idioma], [PdfTemplateId], [PdfTemplateDataVersionId], [MasterTemplateDataId]) VALUES (2, N'<div class="invoice-box">
        <table cellpadding="0" cellspacing="0">
            <tr class="top">
                <td colspan="4">
                    <table>
                        <tr>
                            <td class="title">
                                <img src="http://www.auxilia.cc/img/auxilia.png" alt="l" width="60px" />
                            </td>
                            <td  style="text-align:left">
                               <h2> Payment Guarantee Letter </h2>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
             <tr class="information">
                 
                <td width="10%">
                    To
                </td>
                <td  align  ="left">
                    : {{NombreProveedor}}
                </td>
                <td>From</td>
                <td>: Auxilia Asistencia S.A.</td>
                
            </tr>
            <tr class="information">
                   <td>
                    Department
                </td>
                <td>
                    : Operation 
                </td>
                 <td>Phone</td>
                <td>: +56 2 431 1210</td>
            </tr>
            <tr class="information">
                <td>
                    Affair 
                </td>
                <td>
                    : Expenses Guaranty
                </td>
                <td>
                    Area
                </td>
                <td>
                    : Asistencia Médica
                </td>
              
           </tr>
            
            
              <tr class="information">
                <td>
                     
                </td>
                <td>
                    
                </td>
                <td>
                    Date
                </td>
                <td>
                   : {{Fecha}}
                </td>
              
           </tr>
            
            <tr class="heading ">
                <td colspan="4">
                    Reference:  {{CodigoExpediente}}  {{NombrePaciente}}
                </td>
            </tr>

            <tr class="item information">
                <td colspan="5">
                    <p>
                       Auxilia Club Assistencia, S.A.
                       guaranties {{TipoAsunto}} attention in a 
                       clinic nearby or house call doctor, 
                       with a top initial coverage of {{Monto}} .
                       If needed to perform any new medical 
                       procedures or new complementary exams, 
                       we ask you, expressly, please notify us so we 
                       can approve and guaranty the new procedures. 
                    </p>
                </td>
            </tr>
            <tr class="information">
                <td>
                    Name
                </td>
                <td>
                   : {{NombrePaciente}}
                </td>
            </tr>
            <tr class="information">
                <td>
                    Rut/Passport
                </td>
                <td>
                   : 
                </td>
            </tr>            
            <tr class="information">
                <td>
                    Symptoms
                </td>
                <td>
                   : {{Sintomas}}
                </td>
            </tr>
            
            <tr class="information">
                <td colspan="2">
                    Date of Birth
                     : {{FechaNacimiento}}
                </td>
            </tr>
               
                <tr class="information">
                <td>
                    Address
                </td>
                <td colspan="3">
                   : {{DireccionPaciente}}
                </td>
            </tr>
            
            <tr class="information">
                 <td>
                    Country
                </td>
                <td>
                   : {{PaisPaciente}}
                </td>
            </tr>
            
             <tr class="information">
                <td>
                    Phone
                </td>
                <td>
                    : {{CelularPaciente}}
                </td>
            </tr>
 
               <tr class="information">
                <td>
                    E-mail
                </td>
                <td>
                    : {{MailPaciente}}
                </td>
            </tr>
             
             <tr class="heading">
                <td colspan="4">
                    Bill information:  
                </td>
             </tr>
                <tr class="information">
                <td>
                    Name
                </td>
                <td>
                   : Auxilia Club Asistencia S.A.
                </td>
            </tr>
             <tr class="information">
                <td>
                    Rut
                </td>
                <td colspan="3">
                   : 77.078.150-7
                </td>
            </tr>
                <tr class="information">
                <td>
                    Item
                </td>
                <td colspan="3">
                   : Assistance´s services provider to people and companies
                </td>
            </tr>
            <tr class="information">
                <td>
                    Address
                </td>
                <td colspan="3" >
                   : Las Urbinas 68, Providencia. Santiago de Chile
                </td>
            </tr>
            
            <tr class="information">
                <td>
                    Phone
                </td>
                <td>
                  : +56 2 431 1210
                </td>
            </tr>
               
             <tr class="item information">
                <td colspan="4">
                    <p>
                      Finally, we will be expecting the medical report and bill from this attention.
                      Hopefully this information will be useful.
                    </p>
                    <p>
                        Attentively,
                    </p>
                </td>
            </tr>
            <tr>
               <td colspan="4">
                   <table>
                           <tr>
                                <td width="60px">
                                    <img src="http://www.auxilia.cc/img/auxilia.png" alt="l" width="60px" />
                                </td>
                                <td colspan="3">
                                    {{NombreEjecutivo}} </br>
                                   E-mail:asistenciamedica@auxilia.cl</br>
                                    (+56) 2 431 1210
                                </td>
                           </tr>
                       
                   </table>
               </td>
            </tr>
              <tr class="heading ">
                <td colspan="4">
                   Important:
                </td>
            </tr>
             <tr class="subitem">
                <td colspan="4">
                    <p>
                   Auxilia Club Asistencia informs, that, any additional cost that may exceed the expressed at the top of this document as first guaranty, will not be able to charge or bill us under any circumstances our company, if there is not a previous written approval (fax or email) from any additional cost from the first guaranty. 
                   Auxilia club Asistencia only guarantees 
                   payments on a written form by 
                   email and/or fax, and never by phone. 
                   If there does not exist documents about 
                   mentioned guaranty, Auxilia Club Asistencia will not assume under any circumstances additional payments of any kind. of any kind. 
                    </p>
                </td>
            </tr>
        </table>
    </div>', 1, 1, 1, 1)
GO
INSERT [dbo].[PdfTemplateData] ([Id], [Body], [Idioma], [PdfTemplateId], [PdfTemplateDataVersionId], [MasterTemplateDataId]) VALUES (3, N'<div class="invoice-box">
        <table cellpadding="0" cellspacing="0">
            <tr class="top">
                <td colspan="4">
                    <table>
                        <tr>
                            <td class="title">
                                <img src="http://www.auxilia.cc/img/auxilia.png" alt="l" width="60px" />
                            </td>
                            <td style="text-align:left">
                               <h2> CARTA DE GARANTÍA </h1>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
             <tr class="information">
                <td width="10%">
                    Para
                </td>
                <td  align  ="left">
                    : {{NombreProveedor}}
                </td>
                <td width="10%">
                    De
                </td>
                <td width="30%">
                    : Auxilia Asistencia S.A.
                </td>
            </tr>
            <tr class="information">
  
                <td>
                    Área
                </td>
                <td>
                    : Operaciones
                </td>
                 <td>Teléfono</td>
                <td>: +56 2 431 1210</td>
            </tr>
            <tr class="information">
                <td>
                    Asunto 
                </td>
                <td>
                    : Garantía de gastos
                </td>
                <td>
                    Área
                </td>
                <td>
                    : Operaciones
                </td>
              
              <tr class="information">
                  <td></td>
                  <td></td>
                  <td>
                      Fecha
                  </td>
                  <td>
                      :{{Fecha}}
                  </td>
              </tr>
        
            <tr class="heading ">
                <td colspan="4">
                    Referencia:  {{CodigoExpediente}}  {{NombrePaciente}}
                </td>
            </tr>

            <tr class="item information">
                <td colspan="5">
                    <p>
                        Garantizamos atención médica para
                        {{TipoAsunto}}, cubriendo el 80% de la 
                        atención con un tope inicial 
                        de cobertura de {{Monto}} . 
                        En caso de ser necesaria la realización de 
                        algún procedimiento médico adicional, 
                        o tomar a cargo exámenes complementarios, 
                        les solicitamos expresamente aviso previo 
                        para autorizar y garantizar dichos procedimientos.
                    </p>
                </td>
            </tr>
            <tr class="information">
                <td>
                    Nombre
                </td>
                <td>
                   : {{NombrePaciente}}
                </td>
            </tr>
             <tr class="information">
                <td>
                    Rut/Pasaporte
                </td>
                <td>
                   : 
                </td>
            </tr>
            
            <tr class="information">
                <td colspan="2">
                    Fecha Nacimiento
                     : {{FechaNacimiento}}
                </td>
            </tr>
               
                <tr class="information">
                <td>
                    Dirección
                </td>
                <td colspan="3">
                   : {{DireccionPaciente}}
                </td>
            </tr>
            
            <tr class="information">
                 <td>
                    País
                </td>
                <td>
                   : {{PaisPaciente}}
                </td>
            </tr>
            
             <tr class="information">
                <td>
                    Teléfono
                </td>
                <td>
                    : {{TelefonoPaciente}}
                </td>
            </tr>
            <tr class="information">
                <td>
                    Celular
                </td>
                <td>
                    : {{CelularPaciente}}
                </td>
            </tr>
             
            <tr class="heading ">
                <td colspan="4">
                    Datos Facturación
                </td>
            </tr>
                <tr class="information">
                <td>
                    Nombre
                </td>
                <td>
                   : Auxilia Club Asistencia S.A.
                </td>
            </tr>
             <tr class="information">
                <td>
                    Rut
                </td>
                <td colspan="3">
                   : 77.078.150-7
                </td>
            </tr>
                <tr class="information">
                <td>
                    Giro
                </td>
                <td colspan="3">
                   : Prestación De Servicios De Asistencia A Personas Y Empresas
                </td>
            </tr>
            <tr class="information">
                <td>
                    Dirección
                </td>
                <td colspan="3" >
                   : Las Urbinas 68, Providencia. Santiago de Chile
                </td>
            </tr>
            
            <tr class="information">
                <td>
                    Teléfono
                </td>
                <td>
                  : +56 2 431 1210
                </td>
            </tr>
               
             <tr class="item information">
                <td colspan="4">
                    <p>
                        Finalmente quedamos a la espera del reporte médico y de los costos asociados a dicha atención.
                        Esperando que esta información sea de utilidad,
                        </br>
                        Atentamente,
                    </p>
                </td>
            </tr>
            <tr>
               <td colspan="4">
                   <table>
                           <tr>
                                <td width="60px">
                                    <img src="http://www.auxilia.cc/img/auxilia.png" alt="l" width="60px" />
                                </td>
                                <td colspan="3">
                                    {{NombreEjecutivo}} </br>
                                   E-mail:asistenciamedica@auxilia.cl</br>
                                    (+56) 2 431 1210
                                </td>
                           </tr>
                       
                   </table>
               </td>
            </tr>
              <tr class="heading ">
                <td colspan="4">
                   Importante:
                </td>
            </tr>
             <tr class="subitem">
                <td colspan="4">
                    <p>
                      Auxilia Club Asistencia 
                      informa que cualquier costo adicional al tope señalado expresamente en este documento de primera garantía, no podrá ser cobrado o facturado bajo ninguna circunstancia a nuestra compañía, si no existe autorización previa por escrito (fax o email) de dicho costo adicional a la primera garantía.
                      Auxilia Club Asistencia 
                      sólo realiza garantías de 
                      pagos en forma escrita en 
                      modalidad de email y/o fax y
                      nunca vía telefónica. 
                      Si no existe documentación
                      sobre dichas garantías, 
                      Auxilia Club Asistencia
                      no asumirá bajo ninguna circunstancia pagos 
                      adicionales de cualquier tipo. 
                    </p>
                </td>
            </tr>
        </table>
    </div>', 0, 3, 1, 1)
GO
INSERT [dbo].[PdfTemplateData] ([Id], [Body], [Idioma], [PdfTemplateId], [PdfTemplateDataVersionId], [MasterTemplateDataId]) VALUES (4, N'<div class="invoice-box">
        <table cellpadding="0" cellspacing="0">
            <tr class="top">
                <td colspan="4">
                    <table>
                        <tr>
                            <td class="title">
                                <img src="http://www.auxilia.cc/img/auxilia.png" alt="l" width="60px" />
                            </td>
                            <td  style="text-align:left">
                               <h2> Payment Guarantee Letter </h2>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
             <tr class="information">
                 
                <td width="10%">
                    To
                </td>
                <td  align  ="left">
                    : {{NombreProveedor}}
                </td>
                <td>From</td>
                <td>: Auxilia Asistencia S.A.</td>
                
            </tr>
            <tr class="information">
                   <td>
                    Department
                </td>
                <td>
                    : Operation 
                </td>
                 <td>Phone</td>
                <td>: +56 2 431 1210</td>
            </tr>
            <tr class="information">
                <td>
                    Affair 
                </td>
                <td>
                    : Expenses Guaranty
                </td>
                <td>
                    Area
                </td>
                <td>
                    : Asistencia Médica
                </td>
              
           </tr>
            
            
              <tr class="information">
                <td>
                     
                </td>
                <td>
                    
                </td>
                <td>
                    Date
                </td>
                <td>
                   : {{Fecha}}
                </td>
              
           </tr>
            
            <tr class="heading ">
                <td colspan="4">
                    Reference:  {{CodigoExpediente}}  {{NombrePaciente}}
                </td>
            </tr>

            <tr class="item information">
                <td colspan="5">
                    <p>
                      Auxilia Club Assistencia, S.A. guaranties
                      {{TipoAsunto}} attention covering 80% in a clinic 
                      nearby or house call doctor, with a top initial 
                      coverage of {{Monto}} . If needed to perform a
                      new medical procedures or new complementary exams,
                      we ask you, expressly, previous notice to 
                      approve and guaranty new procedures. 
                    </p>
                </td>
            </tr>
            <tr class="information">
                <td>
                    Name
                </td>
                <td>
                   : {{NombrePaciente}}
                </td>
            </tr>
            
            <tr class="information">
                <td>
                    Symptoms
                </td>
                <td>
                   : {{Sintomas}}
                </td>
            </tr>
            
            <tr class="information">
                <td colspan="2">
                    Date of Birth
                     : {{FechaNacimiento}}
                </td>
            </tr>
               
                <tr class="information">
                <td>
                    Address
                </td>
                <td colspan="3">
                   : {{DireccionPaciente}}
                </td>
            </tr>
            
            <tr class="information">
                 <td>
                    Country
                </td>
                <td>
                   : {{PaisPaciente}}
                </td>
            </tr>
            
             <tr class="information">
                <td>
                    Phone
                </td>
                <td>
                    : {{CelularPaciente}}
                </td>
            </tr>
 
               <tr class="information">
                <td>
                    E-mail
                </td>
                <td>
                    : {{MailPaciente}}
                </td>
            </tr>
             
             <tr class="heading">
                <td colspan="4">
                    Bill information:  
                </td>
             </tr>
                <tr class="information">
                <td>
                    Name
                </td>
                <td>
                   : Auxilia Club Asistencia S.A.
                </td>
            </tr>
             <tr class="information">
                <td>
                Rut/Passport
                </td>
                <td colspan="3">
                   : 77.078.150-7
                </td>
            </tr>
                <tr class="information">
                <td>
                    Item
                </td>
                <td colspan="3">
                   : Assistance´s services provider to people and companies
                </td>
            </tr>
            <tr class="information">
                <td>
                    Address
                </td>
                <td colspan="3" >
                   : Las Urbinas 68, Providencia. Santiago de Chile
                </td>
            </tr>
            
            <tr class="information">
                <td>
                    Phone
                </td>
                <td>
                  : +56 2 431 1210
                </td>
            </tr>
               
             <tr class="item information">
                <td colspan="4">
                    <p>
                      Finally, we will be expecting the medical report and bill from this attention.
                      Hopefully this information will be useful.
                    </p>
                    <p>
                        Attentively,
                    </p>
                </td>
            </tr>
            <tr>
               <td colspan="4">
                   <table>
                           <tr>
                                <td width="60px">
                                    <img src="http://www.auxilia.cc/img/auxilia.png" alt="l" width="60px" />
                                </td>
                                <td colspan="3">
                                    {{NombreEjecutivo}} </br>
                                   E-mail:asistenciamedica@auxilia.cl</br>
                                    (+56) 2 431 1210
                                </td>
                           </tr>
                       
                   </table>
               </td>
            </tr>
              <tr class="heading ">
                <td colspan="4">
                   Important:
                </td>
            </tr>
             <tr class="subitem">
                <td colspan="4">
                    <p>
                   Auxilia Club Asistencia informs, that, any additional cost that may exceed the expressed at the top of this document as first guaranty, will not be able to charge or bill us under any circumstances our company, if there is not a previous written approval (fax or email) from any additional cost from the first guaranty. 
                   Auxilia club Asistencia only guarantees 
                   payments on a written form by 
                   email and/or fax, and never by phone. 
                   If there does not exist documents about 
                   mentioned guaranty, Auxilia Club Asistencia will not assume under any circumstances additional payments of any kind. of any kind. 
                    </p>
                </td>
            </tr>
        </table>
    </div>', 1, 3, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[PdfTemplateData] OFF
GO
SET IDENTITY_INSERT [dbo].[EmailTemplateDataVersion] ON 
GO
INSERT [dbo].[EmailTemplateDataVersion] ([Id], [Body], [Draft]) VALUES (1, N'<table border="0" cellpadding="0" cellspacing="0" class="body">
        <tr>
            <td>&nbsp;</td>
            <td class="container">
                <div class="content">
                    <table class="main">
                        <tr>
                            <td class="wrapper">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <p><strong>Estimado(a): {{ValorProveedorSat}},</strong></p>
                                            <br/>
                                            <p>Junto con saludar le enviamos adjunto a este correo la carta de garantía (PDF) para el paciente {{PersonaNombre}}.
                                            </p>
                                            <p>{{ComplementoCorreo}}</p>
                                            <p>Cordialmente</p>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div class="footer">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td> <img src="https://ii.ct-stc.com/4/logos/empresas/2016/12/16/auxilia-club-asistencia-sa-C6815B186CDC12A4thumbnail.png" alt="Auxilia Logo" class="CToWUd" width="98" height="98" border="0"> </td>
                                <td style="text-align: left"> {{UsuarioDescripcion}}
                                    <br /> Ejecutivo Area de Salud y Viajes
                                    <br /> Las Urbinas # 68,
                                    <br /> Providencia, Santiago
                                    <br /> +56 22 431 1210 </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
</table>', 0)
GO
SET IDENTITY_INSERT [dbo].[EmailTemplateDataVersion] OFF
GO
SET IDENTITY_INSERT [dbo].[EmailTemplateData] ON 
GO
INSERT [dbo].[EmailTemplateData] ([Id], [Idioma], [Cuerpo], [Asunto], [EmailTemplateId], [EmailTemplateDataVersionId], [MasterTemplateDataId]) VALUES (1, 0, N'<table border="0" cellpadding="0" cellspacing="0" class="body">
        <tr>
            <td>&nbsp;</td>
            <td class="container">
                <div class="content">
                    <table class="main">
                        <tr>
                            <td class="wrapper">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <p><strong>Estimado(a): {{Proveedor}},</strong></p>
                                            <br/>
                                            <p>Junto con saludar le enviamos adjunto a este correo la carta de garantía (PDF) para el paciente {{NombrePaciente}}.
                                            </p>
                                            <p></p>
                                            <p>Cordialmente</p>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div class="footer">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td> <img src="https://ii.ct-stc.com/4/logos/empresas/2016/12/16/auxilia-club-asistencia-sa-C6815B186CDC12A4thumbnail.png" alt="Auxilia Logo" class="CToWUd" width="98" height="98" border="0"> </td>
                                <td style="text-align: left"> {{Usuario}}
                                    <br /> Ejecutivo Area de Salud y Viajes
                                    <br /> Las Urbinas # 68,
                                    <br /> Providencia, Santiago
                                    <br /> +56 22 431 1210 </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
</table>', N'Carta de Garantia', 1, 1, 2)
GO
INSERT [dbo].[EmailTemplateData] ([Id], [Idioma], [Cuerpo], [Asunto], [EmailTemplateId], [EmailTemplateDataVersionId], [MasterTemplateDataId]) VALUES (2, 1, N'<table border="0" cellpadding="0" cellspacing="0" class="body">
        <tr>
            <td>&nbsp;</td>
            <td class="container">
                <div class="content">
                    <table class="main">
                        <tr>
                            <td class="wrapper">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <p><strong>Dear: {{Proveedor}},</strong></p>
                                            <br/>
                                            <p>Greetings. We send a copy of the payment guaranty letter (in PDF format) for the patient: {{NombrePaciente}}.</p>
                                            <p></p>
                                            <p>Best Regards</p>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div class="footer">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td> <img src="https://ii.ct-stc.com/4/logos/empresas/2016/12/16/auxilia-club-asistencia-sa-C6815B186CDC12A4thumbnail.png" alt="Auxilia Logo" class="CToWUd" width="98" height="98" border="0"> </td>
                                <td style="text-align: left"> {{Usuario}}
                                    <br /> Ejecutivo Area de Salud y Viajes
                                    <br /> Las Urbinas # 68,
                                    <br /> Providencia, Santiago
                                    <br /> +56 22 431 1210 </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>', N'Payment Guaranty Letter', 1, 1, 2)
GO
INSERT [dbo].[EmailTemplateData] ([Id], [Idioma], [Cuerpo], [Asunto], [EmailTemplateId], [EmailTemplateDataVersionId], [MasterTemplateDataId]) VALUES (3, 0, N'<table border="0" cellpadding="0" cellspacing="0" class="body">
        <tr>
            <td>&nbsp;</td>
            <td class="container">
                <div class="content">
                    <table class="main">
                        <tr>
                            <td class="wrapper">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <p><strong>Estimado(a): {{Proveedor}},</strong></p>
                                            <br/>
                                            <p>Junto con saludar le enviamos adjunto a este correo la carta de garantía (PDF) para el paciente {{NombrePaciente}}.
                                            </p>
                                            <p></p>
                                            <p>Cordialmente</p>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div class="footer">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td> <img src="https://ii.ct-stc.com/4/logos/empresas/2016/12/16/auxilia-club-asistencia-sa-C6815B186CDC12A4thumbnail.png" alt="Auxilia Logo" class="CToWUd" width="98" height="98" border="0"> </td>
                                <td style="text-align: left"> {{Usuario}}
                                    <br /> Ejecutivo Area de Salud y Viajes
                                    <br /> Las Urbinas # 68,
                                    <br /> Providencia, Santiago
                                    <br /> +56 22 431 1210 </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
</table>', N'Carta de Garantia', 2, 1, 2)
GO
INSERT [dbo].[EmailTemplateData] ([Id], [Idioma], [Cuerpo], [Asunto], [EmailTemplateId], [EmailTemplateDataVersionId], [MasterTemplateDataId]) VALUES (4, 1, N'<table border="0" cellpadding="0" cellspacing="0" class="body">
        <tr>
            <td>&nbsp;</td>
            <td class="container">
                <div class="content">
                    <table class="main">
                        <tr>
                            <td class="wrapper">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <p><strong>Dear: {{Proveedor}},</strong></p>
                                            <br/>
                                            <p>Greetings. We send a copy of the payment guaranty letter (in PDF format) for the patient: {{NombrePaciente}}.</p>
                                            <p></p>
                                            <p>Best Regards</p>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div class="footer">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td> <img src="https://ii.ct-stc.com/4/logos/empresas/2016/12/16/auxilia-club-asistencia-sa-C6815B186CDC12A4thumbnail.png" alt="Auxilia Logo" class="CToWUd" width="98" height="98" border="0"> </td>
                                <td style="text-align: left"> {{Usuario}}
                                    <br /> Ejecutivo Area de Salud y Viajes
                                    <br /> Las Urbinas # 68,
                                    <br /> Providencia, Santiago
                                    <br /> +56 22 431 1210 </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>', N'Payment Guaranty Letter', 2, 1, 2)
GO
INSERT [dbo].[EmailTemplateData] ([Id], [Idioma], [Cuerpo], [Asunto], [EmailTemplateId], [EmailTemplateDataVersionId], [MasterTemplateDataId]) VALUES (5, 0, N'<table border="0" cellpadding="0" cellspacing="0" class="body">
         <tr>
            <td>&nbsp;</td>
            <td class="container">
               <div class="content">
                  <table class="main">
                     <tr>
                        <td class="wrapper">
                           <table border="0" cellpadding="0" cellspacing="0">
                              <tr>
                                 <td>
                                    <p><strong>Estimado(a): {{NombrePaciente}},</strong></p>
                                    <p><strong>{{Fecha}}</strong></p>
                                    <br/>       
                                    <p>Junto con saludar y según lo informado a nuestra central de asistencias, este correo es para poder indicar  qué debe hacer con respecto al reembolso de gastos #ValorGarantiaSat ocurrido durante su viaje en el extranjero. En el siguiente enlace deberá completar el formulario con  sus datos personales, detalle de los gastos  y la documentación original de los mismos (boleta, facturas, comprobante de demora de vuelo o equipaje y reportes médicos si los hubiera)</p>
                                    <p>Link:<a href="https://goo.gl/forms/vcCThrh3qxhVu4D93">Formulario de Notificación de Gastos</a></p>
                                    <p>Favor no dude en comunicarse con nosotros al mail <strong><a href="mailto:asistenciamedica@auxilia.cl">asistenciamedica@auxilia.cl</a></strong> o al numero <strong>+56 22 431 1210</strong> ante cualquier duda o consulta.       <br/>                             
                                 </td>
                              </tr>
                           </table>
                        </td>
                     </tr>
                  </table>
                  <div class="footer">
                     <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                           <td>       <img src="https://ii.ct-stc.com/4/logos/empresas/2016/12/16/auxilia-club-asistencia-sa-C6815B186CDC12A4thumbnail.png" alt="Auxilia Logo" class="CToWUd" width="150" height="150" border="0">      </td>
                           <td style="text-align: left">       {{Usuario}}       <br />       Ejecutivo Area de Salud y Viajes       <br />       Las Urbinas # 68,       <br />       Providencia, Santiago       <br />       +56 22 431 1210      </td>
                        </tr>
                     </table>
                  </div>
               </div>
            </td>
            <td>&nbsp;</td>
         </tr>
      </table>', N'Reembolso', 3, 1, 2)
GO
SET IDENTITY_INSERT [dbo].[EmailTemplateData] OFF
GO
