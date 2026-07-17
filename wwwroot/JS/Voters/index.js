$(document).ready(function() {
    // Your code here

    $('#btnVoterLogin').on('click', function(e) {
        e.preventDefault(); // منع الإرسال الافتراضي للنموذج  

        $.ajax({
            url: '/Voters/VoterBallot', // الرابط المطلوب لإرسال الطلب
            type: 'GET', // نوع الطلب
            success: function(response) {
                console.log('Success:', response);
                
                // تنبيه مستخدم باستخدام الدالة العالمية من apiService.js
                showToast('تم التحقق بنجاح! جاري الانتقال إلى ورقة الاقتراع...', 'success');
                
                // التوجيه التلقائي لصفحة الاقتراع الإلكتروني بعد ثانية واحدة ليظهر التنبيه
                setTimeout(function() {
                    window.location.href = '/Voters/VoterBallot';
                }, 1000);
            },
            error: function(xhr, status, error) {
                console.error('Error:', error);
                
                // إظهار تنبيه الخطأ الأنيق باللون الأحمر
                showToast('حدث خطأ أثناء الانتقال لصفحة المقترع. يرجى التحقق من الاتصال والمحاولة مرة أخرى.', 'error');
            }
        }); 
    }); 
});