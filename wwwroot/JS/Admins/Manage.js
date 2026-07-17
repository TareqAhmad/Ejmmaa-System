$(document).ready(function () {
    loadMembers(); // تحميل البيانات عند فتح الصفحة
});

function loadMembers() {
    $.ajax({
        url: '/ClanAdmin/GetMembers', // مسار الـ Action في السيرفر
        type: 'GET',
        success: function (data) {
            let rows = '';
            data.forEach(member => {
                rows += `<tr>
                    <td>${member.fullName}</td>
                    <td>${member.nationalId}</td>
                    <td>${member.sectionName}</td>
                    <td>
                        <button class="btn btn-sm btn-outline-primary" onclick="editMember(${member.id})">تعديل</button>
                    </td>
                </tr>`;
            });
            $('#membersTableBody').html(rows);
        }
    });
}

function editMember(id) {
    // كود فتح مودال التعديل وجلب بيانات الفرد
    alert("جارٍ فتح بيانات العضو رقم: " + id);
}