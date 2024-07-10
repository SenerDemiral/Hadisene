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

//const typeWriter = new Audio("https://www.freesound.org/data/previews/256/256458_4772965-lq.mp3");
//const bip = new Audio("https://codeskulptor-demos.commondatastorage.googleapis.com/pang/pop.mp3");
// https://developers.google.com/assistant/tools/sound-library/alarms
//const bip = new Audio("https://actions.google.com/sounds/v1/cartoon/pop.ogg");
const bip = new Audio("https://actions.google.com/sounds/v1/cartoon/woodpecker.ogg");
function playSound(elmntId) {
	bip.play();
	//document.getElementById(elmntId).play();
}
