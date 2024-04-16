

window.ShowToastr = (type, message) => {
    if (type === 'success') {
        toastr.success(message, 'عملیات مورد نظر با موفقیت انجام شد');
    }
    if (type === 'error') {
        toastr.error(message, 'عملیات مورد نظر با شکست مواجه شد');
    }

}
window.ShowSwal = (type, message) => {
    if (type === 'success') {
        Swal.fire({
            title: "اعلان موفقیت!",
            text: message,
            icon: "success"
        });
    }
    if (type === 'error') {
        Swal.fire({
            title: "اعلان خطا!",
            text: message,
            icon: "error"
        });
    }

}
//az jquery estefade shode 
function showConfirmationModal() {
    $('#confirmationModal').modal('show');
}

function hideConfirmationModal() {
    $('#confirmationModal').modal('hide');
}

