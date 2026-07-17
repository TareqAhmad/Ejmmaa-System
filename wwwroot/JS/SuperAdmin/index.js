

$(document).ready(function() {
    // Your code here

    $('#btnSuperAdminLogin').on('click', function(e) {
        e.preventDefault(); // منع الإرسال الافتراضي للنموذج  

        $.ajax({
            url: '/SuperAdmin/Dashboard', // رابط إرسال الطلب
            type: 'GET', // نوع الطلب
            success: function(response) {
                console.log('Success:', response);
                
                // استدعاء الدالة العالمية مباشرة من ملف apiService.js
                showToast('جاري تحويلك إلى صندوق الاقتراع الإلكتروني...', 'success');
                
                // التوجيه التلقائي لصفحة المقترع
                setTimeout(function() {
                    window.location.href = '/SuperAdmin/Dashboard';
                }, 1000); // تأخير بسيط بمقدار ثانية ليظهر التنبيه الأنيق للمستخدم
            },
            error: function(xhr, status, error) {
                console.error('Error:', error);
                
                // استدعاء الدالة العالمية في حالة الخطأ
                showToast('حدث خطأ أثناء الانتقال لصفحة المقترع. الرجاء المحاولة مرة أخرى.', 'error');
            }
        }); 
    }); 
});