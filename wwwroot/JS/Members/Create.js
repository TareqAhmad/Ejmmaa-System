$(document).ready(function () {
    // 1. تحميل الأقسام عند فتح الصفحة
    loadSectionsIntoSelect();

    // 2. إرسال البيانات
    $('#addMemberForm').on('submit', function (e) {
        e.preventDefault();
        var formData = $(this).serialize(); // تحويل بيانات النموذج لـ Object

        $.ajax({
            url: '/Admins/SaveMember',
            method: 'POST',
            data: formData,
            success: function (res) {
                if (res.success) {
                    alert('تم إضافة الفرد بنجاح');
                    window.location.href = '/Admins/Manage';
                } else {
                    alert('خطأ: ' + res.message);
                }
            }
        });
    });
});

function loadSectionsIntoSelect() {
    $.get('/Admins/GetClanSections', function (res) {
        if (res.success) {
            var select = $('#sectionSelect');
            res.data.forEach(s => {
                select.append(`<option value="${s.sectionId}">${s.sectionName}</option>`);
            });
        }
    });
}