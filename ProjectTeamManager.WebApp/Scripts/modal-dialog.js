$('.delete-link').click(function (e) {
    var a_href = $(this).attr('href'); /* Lấy giá trị của thuộc tính href */
    e.preventDefault(); /* Không thực hiện action mặc định */
    $.ajax({ /* Gửi request lên server */
        url: a_href, /* Nội dung trong Delete.cshtml cụ thể là deleteModal div được server trả về */
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (data) { /* Sau khi nhận được giá */
            $('.body-content').prepend(data); /* body-content div (định nghĩa trong _Layout.cshtml) sẽ thêm deleteModal div vào dưới cùng */
            $('#deleteModal').modal('show'); /* Hiển thị deleteModal div dưới kiểu modal */
            $.validator.unobtrusive.parse(data);
        }
    });
});
$('.create-link').click(function (e) {
    var a_href = $(this).attr('href'); /* Lấy giá trị của thuộc tính href */
    e.preventDefault(); /* Không thực hiện action mặc định */
    $.ajax({ /* Gửi request lên server */
        url: a_href, /* Nội dung trong Delete.cshtml cụ thể là deleteModal div được server trả về */
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (data) { /* sau khi nhận được giá */
            $('.body-content').prepend(data); /* body-content div (định nghĩa trong _layout.cshtml) sẽ thêm deletemodal div vào dưới cùng */
            $('#createModal').modal('show'); /* hiển thị deletemodal div dưới kiểu modal */
            $.validator.unobtrusive.parse(data);
        }
    });
});
$('.edit-link').click(function (e) {
    var a_href = $(this).attr('href'); /* Lấy giá trị của thuộc tính href */
    e.preventDefault(); /* Không thực hiện action mặc định */
    $.ajax({ /* Gửi request lên server */
        url: a_href, /* Nội dung trong Delete.cshtml cụ thể là deleteModal div được server trả về */
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (data) { /* Sau khi nhận được giá */
            $('.body-content').prepend(data); /* body-content div (định nghĩa trong _Layout.cshtml) sẽ thêm deleteModal div vào dưới cùng */
            $('#editModal').modal('show'); /* Hiển thị deleteModal div dưới kiểu modal */
            $.validator.unobtrusive.parse(data);
        }
    });
});
