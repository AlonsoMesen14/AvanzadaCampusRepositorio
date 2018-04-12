$(document).ready(function () {

        $("#CategoryType").change(function () {
            $("#SubCategory").empty();
            $.ajax({






                type: 'POST',

                url: '@Url.Action("GetSubCategories")', 
                dataType: 'json',
                data: { id: $("#CategoryType").val() },
                success: function (subcategories) {

                    $.each(subcategories, function (i, subcategory) {

                        $("#SubCategory").append('<option value="'
                            + subcategory.Value + '">' +
                            subcategory.Text + '</option>');
                    });
                },
                error: function (ex) {
                    alert('Failed to retrieve Sub Categories : ' + ex);
                }
            });
            return false;
        })
    });