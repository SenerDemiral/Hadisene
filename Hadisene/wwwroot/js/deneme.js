function showPrompt(message) {
	return prompt(message, 'Type your name here');
}

function scrollTop(elmnt) {
	document.getElementById(elmnt).scrollTop = 0;
}

function scrollBottom(elmnt) {
	document.getElementById(elmnt).scrollTop = 99999;
}

function showDialogModal(elmntId) {
	document.getElementById(elmntId).showModal();
}

function closeDialog(elmntId) {
	document.getElementById(elmntId).close();
}

function hardReload() {
	location.reload(true);
}

function playSound01(elmntId) {
	document.getElementById(elmntId).play();
}
