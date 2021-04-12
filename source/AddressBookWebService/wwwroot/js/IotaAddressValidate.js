jQuery.validator.addMethod("iotaaddress",
    function (value, element, param) {
        console.log("starting iotaaddress");
        var response;
        $.when($.ajax({
            type: "GET",
            async: false, //important!
            url: "https://localhost:44383/api/address/isiotaaddress/" + value,
            cache: false
        })).done(function (data, textStatus, jqXHR) {
            console.log("background call done. Response: " + data);
            console.log(data);
            response = data;
        });

        if (response) $("#addressSubmit").removeAttr("disabled");
        else $("#addressSubmit").prop("disabled", true);

        console.log("finished iotaaddress " + response);

        return response;
    });

jQuery.validator.unobtrusive.adapters.addBool("iotaaddress");