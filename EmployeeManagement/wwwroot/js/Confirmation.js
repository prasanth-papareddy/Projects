function DeleteConfirm(event, e) {
    debugger;
    swal({
        title: 'Are you sure?',
        text: "to deleting this " + e,
        type: 'warning',        
        showConfirmButton: true,
        confirmButtonText: 'Yes',
        confirmButtonClass: 'btn btn-success',
        showCancelButton: true,
        cancelButtonText: 'No',
        cancelButtonClass: 'btn btn-danger',
    }, function (isConfirm) {
        if (isConfirm) {
            $('form').submit();
            return true;
        } else {
            return false;
        }
    });
    return false;
}

function UpdateConfirm(event) {
    swal({
        title: 'Are you sure?',
        text: "update the provided details",
        type: 'warning',
        showCancelButton: true,
        cancelButtonText: 'No',
        cancelButtonClass: 'btn btn-danger',
        showConfirmButton: true,
        confirmButtonText: 'Yes',
        confirmButtonClass: 'btn btn-success'
    }, function (isConfirm) {
        if (isConfirm) {
            $('form').submit();
            return true;
        } else {
            return false;
        }
    });
    return false;
}
