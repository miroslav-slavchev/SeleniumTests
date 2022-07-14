class Employee {
    constructor(firstName, lastName, gender, technologies, tools, english, job, careetNotes) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.gender = gender;
        this.technologies = technologies;
        this.tools = tools;
        this.english = english;
        this.job = job;
        this.careerNotes = careetNotes;
    }
}

function getEmployeeData() {
    var firstName = document.getElementById('fname').value;
    var lastName = document.getElementById('lname').value;

    var radioButtons = document.getElementsByName('gender');
    var gender = radioButtons[0].checked ? radioButtons[0].value : radioButtons[1].value;

    var programmingLanguages = document.querySelectorAll('#programming-languages input[type=checkbox]');
    var techArray = [];
    for (var technology of programmingLanguages) {
        if (technology.checked) {
            techArray.push(technology.value);
        }
    }

    var autoTools = document.querySelectorAll('#auto-tools input[type=checkbox]');
    var toolsArray = [];
    for (var technology of autoTools) {
        if (technology.checked) {
            toolsArray.push(technology.value);
        }
    }

    var english = document.querySelector('#english input').value;

    var job = document.getElementById('job').value;

    var notes = document.getElementById('comment').value;

    var employeeData = new Employee(firstName, lastName, gender, techArray, toolsArray, english, job, notes);
    return employeeData;
}

function submitData() {
    var employeeData = getEmployeeData();
    document.getElementById('register').remove();
    alert('Successfully registered an user!');
    appendData(employeeData);
}

function appendData(employeeData) {
    var panel = getDivPanel();
    var panelHeading = panel.querySelector('.panel-heading');
    var icon = buildIcon('glyphicon-user');
    icon.appendChild(document.createTextNode(' User Information'));
    panelHeading.appendChild(icon);
    
    var panelBody = panel.querySelector('.panel-body');
    var nameP = buildParahraph('Name: ' + employeeData.firstName + ' ' + employeeData.lastName + ', Gender:' + employeeData.gender);
    nameP.setAttribute('id', 'personal-info');
    panelBody.appendChild(nameP);

    var favouriteTechP;
    if (employeeData.technologies.length > 0) {
        favouriteTechP = buildParahraph('Favourite technologies: ');
        for (var technology of employeeData.technologies) {
            favouriteTechP.appendChild(buildInfoLabel(technology));
        }
    }
    else {
        favouriteTechP = buildParahraph('No favourite technologies.');
    }
    favouriteTechP.setAttribute('id', 'favourite-technologies');
    panelBody.appendChild(favouriteTechP);

    var favouriteToolsP;
    if (employeeData.tools.length > 0) {
        var favouriteToolsP = buildParahraph('Favourite automation tools: ');
        for (var technology of employeeData.tools) {
            favouriteToolsP.appendChild(buildInfoLabel(technology));
        }
    }
    else {
        favouriteToolsP = buildParahraph('No favourite automation tools.');
    }
    favouriteToolsP.setAttribute('id', 'favourite-tools');
    panelBody.appendChild(favouriteToolsP);

    var englishP;
    if (employeeData.english > 50) {
        englishP = buildParahraph('The level of English is');
        englishP.appendChild(buildGreenLabel('good'));
    }
    else {
        var englishP = buildParahraph('The level of English is ');
        englishP.appendChild(buildYellowLabel('not good enough'));
    }
    englishP.setAttribute('id', 'english');
    panelBody.appendChild(englishP);

    var job = buildParahraph('Currently working as ');
    job.setAttribute('id', 'job');
    job.appendChild(buildBadge(employeeData.job));
    panelBody.appendChild(job);

    if (employeeData.careerNotes != '') {
        var carrerNotes = document.createElement('div');
        carrerNotes.classList.add('alert', 'alert-info');
        carrerNotes.appendChild(document.createTextNode(employeeData.careerNotes));
        panelBody.appendChild(carrerNotes);

    }
    
    document.body.appendChild(panel);
}
function getDivPanel() {
    var divPanel = document.createElement('div');
    divPanel.classList.add('panel', 'panel-info');
    var divHeading = document.createElement('div');
    divHeading.classList.add('panel-heading');
    var divBody = document.createElement('div');
    divBody.classList.add('panel-body');
    divPanel.appendChild(divHeading);
    divPanel.appendChild(divBody);
    return divPanel;
}

function buildIcon(iconClass) {
    var span = document.createElement('span');
    span.classList.add('glyphicon');
    span.classList.add(iconClass)
    return span;
}

function buildParahraph(text) {
    var p = document.createElement('p');
    var text = document.createTextNode(text);
    p.appendChild(text);
    return p;
}

function buildBadge(text) {
    var span = document.createElement('span');
    var text = document.createTextNode(text);
    span.appendChild(text);
    span.classList.add('badge');
    return span;
}

function buildInfoLabel(text) {
    var label = buildLabel(text);
    label.classList.add('label-info');
    return label;
}

function buildGreenLabel(text) {
    var label = buildLabel(text);
    label.classList.add('label-success');
    return label;
}

function buildYellowLabel(text) {
    var label = buildLabel(text);
    label.classList.add('label-warning');
    return label;
}

function buildLabel(text) {
    var span = document.createElement('span');
    var text = document.createTextNode(text);
    span.appendChild(text);
    span.classList.add('label');
    return span;
}

function disableButton(button) {
    button.setAttribute('disabled', '');
    button.classList.add('disabled-button');
}

function enableButton(button) {
    button.removeAttribute('disabled');
    button.classList.remove('disabled-button');
    button.classList.add('enabled-button');
}

function setTooltipText(text) {
    var tooltip = document.getElementsByClassName('tooltiptext')[0];
    tooltip.innerHTML = '';
    tooltip.appendChild(document.createTextNode(text));
}

function manageRegisterButton() {
    var registerButton = document.getElementById('submit');
    var clearButton = document.getElementById('clear');
    var firstName = document.getElementById('fname').value;
    var lastName = document.getElementById('lname').value;

    if (firstName == '' || lastName == '') {
        disableButton(registerButton);
        //setTooltipText('Enter First name and Last name to enable Register button.');

        if (firstName != '' || lastName != '') {
            enableButton(clearButton);
        }
        else {
            disableButton(clearButton);
        }
    }
    else {
        enableButton(registerButton);
        //setTooltipText('Click Register button to submit data.');
        enableButton(clearButton);
    }
}

function showTooltip() {
    var tooltip = document.getElementsByClassName('tooltiptext')[0];
    tooltip.style.visibility = 'visible';
}

function hideTooltip() {
    var tooltip = document.getElementsByClassName('tooltiptext')[0];
    tooltip.style.visibility = 'hidden';
}


function clearData() {
    window.location.reload();
}

function showInfo() {
    alert('That is a register form. Provide user details to register a new employee.')
}
