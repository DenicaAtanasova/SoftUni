function validate() {
	$('#submit').on('click', function(e){
        e.preventDefault();

        let isValidUsername = validateField(/^[a-z0-9]{3,20}$/gi, '#username');
        let isValidPassword = validateField(/^[\w]{5,15}$/gi, '#password');
        let isValidConfirmPassword = validateField(/^[\w]{5,15}$/gi, '#confirm-password');
        let isValidEmail = validateField(/^[\w]+@[\w\.]+$/gi, '#email');      
        let isCompanyNumberValid = validateField(/.+/gi, '#companyNumber');

        if (isValidUsername && isValidPassword && isValidConfirmPassword && isValidEmail && isCompanyNumberValid) {
            $('#valid').show();
        } else{
            $('#valid').hide();
        }
          
    });

    $('#company').on('change', function () {
		if ($('#company').is(':checked')) {
			$('#companyInfo').show();
		} else {
			$('#companyInfo').hide();
		}
    });
    
    function validateField(pattern, selector){

        let isValidField = pattern.test($(selector).val());

        if (selector === '#confirm-password') {
            isValidField = isValidField && $(selector).val() === $('#password').val();
        }

        if(selector === '#companyNumber'){
            if(!$('#company').is(':checked')){
                isValidField = true;
            } else{
                isValidField = $(selector).val() >= 1000 && $(selector).val() <= 9999;
            }
        }

        changeBorder(isValidField, selector);
        return isValidField;
    }

    function changeBorder(isValidField, selector){

        if (isValidField) {
            $(selector).css('border-color','');
        } else{
            $(selector).css('border-color','red');
        }
    }
}