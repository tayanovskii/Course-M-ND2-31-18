$.validator.addMethod("expirationdate",
    function(value, element, params) {
        var currentDate = new Date();
        var expirationMonthFieldName = params.value;
        var expirationMonth = $("input[name='" + expirationMonthFieldName + "']").val();
        if (value < currentDate.getFullYear()) return false;
        if (value == currentDate.getFullYear() && expirationMonth <= (currentDate.getMonth()+1)) return false;
        return true;
    });

$.validator.unobtrusive.adapters.add('expirationdate', ["value"], function (options) {
    options.rules['expirationdate'] = options.params;
    options.messages['expirationdate'] = options.message;
});