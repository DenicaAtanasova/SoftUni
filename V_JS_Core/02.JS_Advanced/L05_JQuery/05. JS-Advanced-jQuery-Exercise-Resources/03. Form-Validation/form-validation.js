function validate() {
	$('#submit').on('click', function(e){
        e.preventDefault();

        let usernamePattern = /^[a-z0-9]{3,20}$/gi;
        let usernameSelector = '#username';
        let isValidUsername = validateField(usernamePattern, usernameSelector);

        let passwordPattern = /^[\w]{5,15}$/gi;
        let passwordSelector = '#password';
        let isValidPassword = validateField(passwordPattern, passwordSelector);

        let confirmPasswordPattern = /^[\w]{5,15}$/gi;
        let confirmPasswordSelector = '#confirm-password';
        let isValidConfirmPassword = validateField(confirmPasswordPattern, confirmPasswordSelector);

        let emailPattern = /^[\w]+@[\w\.]+$/gi;
        let emailSelector = '#email';
        let isValidEmail = validateField(emailPattern, emailSelector);
       
        let companyNumberSelector = '#companyNumber';
        let isCompanyNumberValid = validateField(/.+/gi, companyNumberSelector);

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