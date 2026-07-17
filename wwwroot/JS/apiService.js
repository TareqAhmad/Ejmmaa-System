function showToast(msg, iconType = 'success') {
    const Toast = Swal.mixin({
        toast: true,
        position: 'bottom-start', // المكان: أعلى اليمين
        showConfirmButton: false,
        timer: 5000, // يختفي بعد 3 ثوانٍ
        timerProgressBar: true,
        background:'#333',
        color:'#fff',


        customClass: {
            title: 'my-toast-title' 
        }
    });

    Toast.fire({
        icon: iconType, // 'success', 'error', 'warning', 'info'
        title: msg
    });
}



//------------------------------------------------------------------------



