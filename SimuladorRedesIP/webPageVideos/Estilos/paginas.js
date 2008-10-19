///////////////////////////////////////////////////////////////////////////////////////////////////
// TES America Andina Ltda, Derechos Reservados (C)
// Bogotá D.C., Colombia
//
//         888888 888888 888888       db    88   88 888888 88 Yb   88  88888    db
//           88   88__   88__        dPYb   8888888 88__   88__dP  88  88      dPYb
//           88   88""     ""88     dP__Yb  88 " 88 88""   88""8   88  88     dP__Yb
//           88   888888 888888    dP""""Yb 88   88 888888 88  88  88  88888 dP""""Yb
//
//$Id: paginas.js 3745 2006-09-06 14:47:05Z andres $
///////////////////////////////////////////////////////////////////////////////////////////////////


//////////////////////////////////////////////////////////////////////////
// Variables globales
var docArea = "";					// Area a la que pertenece la página
var docTipo = "";					// Tipo de documento ESTANDAR, PROCEDIMIENTO, etc.
var docID = "";						// ID del documento en el sistema de calidad
var docFecha = "";					// Fecha de elaboración del documento
var base = "http://servidor/";		// Ruta base 


//////////////////////////////////////////////////////////////////////////
// Handlers de eventos
window.onload = cargarDocumento;
window.onresize = resizeBanner;


//////////////////////////////////////////////////////////////////////////
// Inicializa el documento
function cargarDocumento()
{
	var spath = document.URL;
	spath = spath.toLowerCase();
	var pos = spath.lastIndexOf("/intranet/");
	if ((pos >= 0) && (pos < spath.length))		base = spath.substr(0, pos + 10);

	// Escribir el encabezado del documento
	escribirHeader();
	
	// Escribir el pie de página del documento
	escribirFooter();
	
	// Ajustar el documento para mantener el encabezado siempre visible
	resizeBanner();
}



//////////////////////////////////////////////////////////////////////////
// Escribe el encabezado del documento
function escribirHeader()
{
	var menu = "";
	var menuDesarrollo = false;
	var menuProductos = false;

	// Recorrer la lista de metadatos del documento para determinar
	// las características del encabezado
	var mColl = document.all.tags("META");
	for (i = 0; i < mColl.length; i++)
	{
		var metaName = mColl(i).name.toUpperCase();
		var metaValue = mColl(i).content.toString();
		
		switch (metaName)
		{
		case "AREA":					docArea = mColl(i).content;			break;
		case "TIPODOCUMENTO":			docTipo = mColl(i).content;			break;
		case "IDDOCUMENTO":				docID = mColl(i).content;			break;
		case "FECHADOCUMENTO":			docFecha = mColl(i).content;		break;
		case "MENUTES":					menu += MenuTES(base);				break;
		case "MENUDESARROLLO":			menu += MenuDesarrollo(base);		break;
		case "MENUITPP":				menu += MenuDesarrollo(base);		break;
		case "MENUPROVEEDORES":			menu += MenuProveedores(base);		break;
		case "MENUINGENIERIA":			menu += MenuIngenieria(base);		break;
		case "MENUCARTOGRAFIA":			menu += MenuCartografia(base);		break;
		case "MENUCOMERCIAL":			menu += MenuComercial(base);		break;
		case "MENURRHH":			    menu += MenuRrHh(base);		break;
		case "MENUCONTABILIDAD":		menu += MenuContabilidad(base);		break;
		case "MENUADMINISTRACION":		menu += MenuAdministracion(base);		break;
		}
	}
	
	// Poner el encabezado del documento
	var header = '<div id="nsbanner"><table class="bannerparthead"><tr>';
	header += '<td rowspan=3><a href="' + base + 'General/Default.htm"><img src="' + base + 'General/TES2.jpg"></a></td>';
	header += '<td colspan=2 style="text-align: right"><a href="' + base + 'General">TES</a> | <a href="' + base + 'Cartografia/">Cartograf&iacute;a</a> | <a href="' + base + 'Desarrollo/">Desarrollo</a> | <a href="' + base + 'Ingenieria/">Ingenier&iacute;a</a> | <a href="' + base + 'Comercial/">Comercial</a> | <a href="' + base + 'RRHH/">Recursos humanos</a> | <a href="' + base + 'Contabilidad/">Contabilidad</a> | <a href="' + base + 'Administracion/">Administraci&oacute;n</a>&nbsp;</td>';
	header += '</tr><tr>';
	header += '<td rowspan=2 style="padding: 0px 1em 0px 0.5em; font-size: 200%;">' + docArea + '</td>';
	header += '<td style="font-size: 125%;">' + document.title + '</td>';
	header += '</tr><tr>';
	header += '<td width="100%">' + menu + '</td>';
	header += '</tr></table>';

	try { document.body.insertAdjacentHTML("afterBegin", header); } catch (e) {}
}



//////////////////////////////////////////////////////////////////////////
// Escribe el pie de página del documento
function escribirFooter()
{
	// Obtener el año de elaboración del documento para la parte
	// de derechos de autor en el pie de página
	var anio = "";
	try { anio = docFecha.substring(docFecha.lastIndexOf("/") + 1); } catch (e) {}
	if (anio == "")
	{
		var d = new Date();
		anio = d.getFullYear().toString();
	}
	
	// Escribir el pié de página
	var footer = '<div class="footer"><hr><p><a href="http://www.tesamerica.com.co">&copy; ' + anio + ' TES America Andina Ltda. Derechos Reservados.</a></p></div>';
	try { document.all.item("nstext").insertAdjacentHTML("beforeEnd", footer); } catch (e) {}
}



//////////////////////////////////////////////////////////////////////////
// Mantiene el encabezado siempre visible
function resizeBanner()
{
	if (document.body.clientWidth == 0) return;

	// Obtener las secciones de encabezado y contenido
	var oBanner= document.all.item("nsbanner");
	var oText = document.all.item("nstext");
	if ((oText == null) || (oBanner == null)) return;

	try
	{
		// Ajustar los modos de scroll
		document.body.scroll = "no";
		oText.style.overflow = "auto";
 		
 		// Ajustar los tamaños de las secciones
 		oBanner.style.width = document.body.offsetWidth - 4;
		oText.style.width = document.body.offsetWidth - 4;
		oText.style.top = 0;
		
		// La sección de contenido es del tamaño del documento menos el ecabezado
		if (document.body.offsetHeight > oBanner.offsetHeight + 4)
    		oText.style.height = document.body.offsetHeight - (oBanner.offsetHeight + 4);
		else 
			oText.style.height = 0;
	}
	catch (e)
	{
		return;
	}
}


//////////////////////////////////////////////////////////////////////////
// Crea el menú de TES
function MenuTES(base)
{
	var menu = "";

	menu += '<a href="' + base + 'General/Default.htm">Inicio</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Proveedores/Proveedores.aspx">Proveedores</a>&nbsp;|&nbsp;';
	
	return menu;
}


//////////////////////////////////////////////////////////////////////////
// Crea el menú de Desarrollo
function MenuDesarrollo(base)
{
	var menu = "";

	menu += '<a href="' + base + 'Desarrollo/Default.htm">Inicio</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Desarrollo/Documentacion.htm">Documentaci&oacute;n</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Desarrollo/itpp/Productos.aspx">Productos</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Desarrollo/itpp/Versiones.aspx">Versiones</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Desarrollo/itpp/Entregas.aspx">Entregas</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Desarrollo/itpp/Backups.aspx">Backups</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Desarrollo/itpp/Soportes.aspx">Soporte</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Desarrollo/Links.htm">Links</a>';
	
	return menu;
}


//////////////////////////////////////////////////////////////////////////
// Crea el menú de itpp
function MenuITPP(base)
{
	var menu = "";

	menu += '<a href="' + base + 'Desarrollo/Default.htm">Desarrollo</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Desarrollo/itpp/Default.htm">Inicio</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Desarrollo/itpp/Productos.aspx">Productos</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Desarrollo/itpp/Versiones.aspx">Versiones</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Desarrollo/itpp/Entregas.aspx">Entregas</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Desarrollo/itpp/Backups.aspx">Backups</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Desarrollo/itpp/Soportes.aspx">Soporte</a>';
	
	return menu;
}


//////////////////////////////////////////////////////////////////////////
// Crea el menú de proveedores
function MenuProveedores(base)
{
	var menu = "";

	menu += '<a href="' + base + 'General/Default.htm">Inicio</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Proveedores/Proveedores.aspx">Proveedores</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Proveedores/Indicador.aspx">Indicador</a>';
	
	return menu;
}


//////////////////////////////////////////////////////////////////////////
// Crea el menú de Ingeniería
function MenuIngenieria(base)
{
	var menu = "";

	menu += '<a href="' + base + 'Ingenieria/Default.htm">Inicio</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Ingenieria/Documentacion.htm">Documentaci&oacute;n</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Ingenieria/Laboratorio/Equipos.aspx">Equipos</a>';
	
	return menu;
}


//////////////////////////////////////////////////////////////////////////
// Crea el menú de cartografía
function MenuCartografia(base)
{
	var menu = "";

	menu += '<a href="' + base + 'Cartografia/Default.htm">Inicio</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Cartografia/Documentacion.htm">Documentaci&oacute;n</a>';
	
	return menu;
}

//////////////////////////////////////////////////////////////////////////
// Crea el menú de RRHH
function MenuRrHh(base)
{
	var menu = "";

	menu += '<a href="' + base + 'RRHH/Default.htm">Inicio</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'RRHH/Documentacion.htm">Documentaci&oacute;n</a>';
	
	return menu;
}


//////////////////////////////////////////////////////////////////////////
// Crea el menú de Contabilidad
function MenuContabilidad(base)
{
	var menu = "";

	menu += '<a href="' + base + 'Contabilidad/Default.htm">Inicio</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Contabilidad/Documentacion.htm">Documentaci&oacute;n</a>';
	
	return menu;
}


//////////////////////////////////////////////////////////////////////////
// Crea el menú de comercial
function MenuComercial(base)
{
	var menu = "";

	menu += '<a href="' + base + 'Comercial/Default.htm">Inicio</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Comercial/Documentacion.htm">Documentaci&oacute;n</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Clientes/Inicio.asp">Clientes</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Ventas/PronosticoVentas.aspx">Ventas</a>';
	
	return menu;
}

//////////////////////////////////////////////////////////////////////////
// Crea el menú de ...
function Menu(base)
{
	var menu = "";

	menu += '<a href="' + base + 'General/Default.htm">Inicio</a>&nbsp;|&nbsp;';
	
	return menu;
}

//////////////////////////////////////////////////////////////////////////
// Crea el menú de Administracion
function MenuAdministracion(base)
{
	var menu = "";

	menu += '<a href="' + base + 'Administracion/Default.htm">Inicio</a>&nbsp;|&nbsp;';
	menu += '<a href="' + base + 'Administracion/Documentacion.htm">Documentaci&oacute;n</a>';
	
	return menu;
}



///////////////////////////////////////////////////////////////////////////////////////////////////
// $Log$
// Revision 1.1  2006/09/06 14:44:08  andres
// *** empty log message ***
//
// Revision 1.4  2006/03/21 05:42:36  JuanFelipe
// *** empty log message ***
//
// Revision 1.3  2006/01/18 19:30:47  JuanFelipe
// Actualizaciones pequeñas
//
// Revision 1.2  2004/05/04 23:55:33  diego
// Final sprint 2004-107_003
//
// Revision 1.1  2004/04/27 18:45:34  diego
// Creación del producto Intranet
// 
