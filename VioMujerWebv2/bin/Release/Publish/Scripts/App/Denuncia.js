var controlador = 'Denuncia';
function changePage(nPage) {
    RedirectTo(controlador, 'ChangePage?newPage=' + nPage);
}

function ChangeFilterField(field) {
    RedirectTo(controlador, 'ChangeFilterField?field=' + field);
}

function OnRowClikc(id) {
    RedirectTo(controlador, 'Registro?Id=' + id);
}

function RedirectTo(controller, action) {
    if (action == null) {
        window.location.href = self.location.origin + '/' + controller;
    }
    else {
        window.location.href = self.location.origin + '/' + controller + '/' + action;
    }
}

function OnFilterChanged(e, control) {
    if (e.keyCode === 13) {
        e.preventDefault();
        var DenunciaId = document.getElementById('DenunciaId').value;
        var Descripcion = document.getElementById('Descripcion').value;
        var Direccion = document.getElementById('Direccion').value;
        var Departamento = document.getElementById('Departamento').value;
        var Ciudad = document.getElementById('Ciudad').value;
        var AtendidoPor = document.getElementById('AtendidoPor').value;

        var filtro = 'DenunciaId=' + DenunciaId + '&Descripcion=' + Descripcion + '&Departamento=' + Departamento + '&Ciudad=' + Ciudad + '&AtendidoPor=' + AtendidoPor + '&Direccion=' + Direccion;
        RedirectTo(controlador, 'SetFilter?' + filtro);
    }
}
