function GenrateDataTableSearch(tableId, URL, columnsData, searchParams)
{
    $(tableId).DataTable({
        "processing": true,
        "serverSide": true,
        "responsive": true,
        "searching": false,
        "lengthChange": false,
        "iDisplayLength": 10,
        "columns": columnsData,
        "scrollY": "400px",
        "scrollX": true,
        "scrollCollapse": true,
        //"fixedColumns": {
        //    leftColumns: 4,
        //    rightColumns: 1
        //},
        "language": {
            "zeroRecords": "Không tìm thấy dữ liệu",
            "infoEmpty": "0/0 Kết quả"
        },
        "ajax": {
            "url": URL,
            "type": "POST",
            "data": searchParams
        },

        "destroy": true
    });

}

function ShowWaiting() {
    $("#popup-overlay").css("display", "block");
}
function HideWaiting() {
    $("#popup-overlay").css("display", "none");
}


function FormToObject(formName, suffixReplace) {
    var array = $(formName).serializeArray();
    var json = {};

    jQuery.each(array, function () {
        var nameobj = "";
        if (suffixReplace !== null && suffixReplace !== "") {
            nameobj = this.name.replace(suffixReplace, "");
        } else {
            nameobj = this.name;
        }
        json[nameobj] = this.value || '';
    });
    return json;
}

function AlertSuccess(contentMessage) {
    return "<span class='alertsuccess'><i class='glyphicon glyphicon-ok'></i>&nbsp;" + contentMessage + "</span>";
}
function AlertFail(contentMessage) {
    return "<span class='alertfail'><i class='glyphicon glyphicon-info-sign'></i>&nbsp;" + contentMessage + "</span>";
}


function ConverFormatDate(currentFormatDate) {
    if (currentFormatDate == null || currentFormatDate == "") {
        return null;
    } else {
        var arr = currentFormatDate.split("/");
        var newFormatDate = arr[2] + "/" + arr[1] + "/" + arr[0];
        return newFormatDate;
    }
   
}

//function RenderNumerFormat(data) {
//    var res = "";
//    if (data !== undefined && data != null) {
//        res = data.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
//    }
//    return "<div style='width:100%;text-align:right;'>" + res + "</div>";
//}

function SubStrinColumn(data, len) {
    let textReturn = "";
    if (data != null && data.length > len) {
        textReturn = data.substring(0, len);
    } else {
        textReturn = data;
    }
    return "<span title='" + data+"'>" + textReturn+"</span>";
}

function RenderNumerFormat(data) {
    var res = "";
    if (data !== undefined && data > 0) {
        res = data.toLocaleString('de-DE')
    }
    else {
        res = "0";
    }
    return "<div style='width:100%;'>" + res + "</div>";
}
function DeRenderNumerFormat(data) {
    debugger
    if (data != null || data != undefined)
    {
        data = data.toString().replace(".", "");
    }
    debugger;
    return data;
}
function RenderNumerFormat_NotHTML(data) {
    var res = "";
    if (data !== undefined && data > 0) {
        res = data.toLocaleString('de-DE')
    }
    return res;
}

function generateCode(prefix) {
    let attempts = 0;
    let code = prefix + '-' + Math.random().toString(36).substr(2, 8).toUpperCase();

    // Retry the uniqueness check until it succeeds or max attempts are reached
    while (attempts < 3) {
        let isUnique = checkProjectCodeUniqueness(prefix, code);

        if (isUnique) {
            return code;  // Return the code if it's unique
        } else {
            attempts++;  // Increment the retry counter
            console.log(`Attempt ${attempts}: Code is not unique. Retrying...`);
            code = prefix + '-' + Math.random().toString(36).substr(2, 5).toUpperCase();  // Generate a new code
        }
    }

    // If the code is still not unique after 3 attempts, return a message or an empty string
    toast.error("Failed to generate a unique code after 3 attempts.");
    return '';  // You can also return a default value or throw an error if necessary
}

function checkProjectCodeUniqueness(prefix,code) {
    let isUnique = false;  // Default value

    $.ajax({
        url: '/Project/CheckCodeUnique',
        type: 'POST',
        data: {
            prefix: prefix,
            code: code
        },
        async: false,  // Make the request synchronous
        success: function (response) {
            if (response.isSuccess === true) {
                isUnique = true;  // Set the flag to true if code is unique
            } else {
                isUnique = false;  // Set to false if code is not unique
            }
        },
        error: function () {
            console.log("Error checking code uniqueness");
            isUnique = false;  // Set to false on error
        }
    });

    return isUnique;  // Return the result
}