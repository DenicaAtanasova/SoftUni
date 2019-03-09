function toggle() {
  let extra = document.getElementById('extra');
  let button = document.querySelector('.button');
  if (button.textContent === 'Less') {
    button.textContent = 'More';
    extra.style.display = 'none';
  } else {
    button.textContent = 'Less';
    extra.style.display = 'block';
  }
}