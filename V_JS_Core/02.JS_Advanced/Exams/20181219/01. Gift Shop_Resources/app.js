function solution() {
	let $type = $('#toyType');
	let $price = $('#toyPrice');
	let $description = $('#toyDescription');

	let type = $type.val();
	let price = $price.val();
	let description = $description.val();

	if(type && Number(price) && description){ 
		let $gift = $('<div>').addClass('gift')
		.append($('<img>').attr('src', 'gift.png'))
		.append($('<h2>').text(type))
		.append($('<p>').text(description))
		.append($('<button>').text(`Buy it for $${price}`).on('click', () => $gift.remove()))
		.appendTo($('#christmasGiftShop'));

		$type.val('');
		$price.val('');
		$description.val('');
	}
}