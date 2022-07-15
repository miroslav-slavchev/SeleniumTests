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
    var firstName = getEmployeeDataFirstName();
    var lastName = getEmployeeDataLastName();
    var gender = getGender();
    var techArray = getTechArray();
    var toolsArray = getToolsArray();
    var english = getEnglish();
    var job = getJob();
    var notes = getNotes();

    var employeeData = new Employee(firstName, lastName, gender, techArray, toolsArray, english, job, notes);
    return employeeData;
}

function getEmployeeDataFirstName() {
    var firstName = document.getElementById('fname').value;
    return firstName;
}

function getEmployeeDataLastName() {
    var lastName = document.getElementById('lname').value;
    return lastName;
}

function getGender() {
    var radioButtons = document.getElementsByName('gender');
    var gender = radioButtons[0].checked ? radioButtons[0].value : radioButtons[1].value;
    return gender;
}

function getTechArray() {
    var programmingLanguages = document.querySelectorAll('#programming-languages input[type=checkbox]');
    var techArray = [];
    for (var technology of programmingLanguages) {
        if (technology.checked) {
            techArray.push(technology.value);
        }
    }
    return techArray;
}

function getContextTechArray() {
    var programmingLanguages = document.querySelector('input[type=checkbox][value=Java]').parentElement.parentElement.querySelectorAll('input[type=checkbox]');
    var techArray = [];
    for (var technology of programmingLanguages) {
        if (technology.checked) {
            techArray.push(technology.value);
        }
    }
    return techArray;
}

function getToolsArray() {
    var autoTools = document.querySelectorAll('#auto-tools input[type=checkbox]');
    var toolsArray = [];
    for (var technology of autoTools) {
        if (technology.checked) {
            toolsArray.push(technology.value);
        }
    }
    return toolsArray
}

function getEnglish() {
    var english = document.querySelector('#english input').value;
    return english;
}

function getJob() {
    var job = document.getElementById('job').value;
    return job;
}

function getNotes() {
    var notes = document.getElementById('comment').value;
    return notes;
}

var newHtmlContainer = '<div class="container" id="register"><h2>Register Form</h2 > <hr/> <form id="sections"> <div class="section" id="personal_info"> <h4>Personal information</h4> <div class="form-group-fields"> <div class="form-group" data-form-group-type="text-input"> <label for="fname">First Name:</label> <span class="control-value"></span> <button type="button" class="btn btn-default btn-sm" onclick="openModalEdit(this)"> <span class="glyphicon glyphicon-pencil"></span> Edit </button> <div class="control" hidden> <input type="text" class="form-control" id="fname" /> </div> </div> <div class="form-group" data-form-group-type="text-input"> <label for="lname">Last Name:</label> <span class="control-value"></span> <button type="button" class="btn btn-default btn-sm" onclick="openModalEdit(this)"> <span class="glyphicon glyphicon-pencil"></span> Edit </button> <div class="control" hidden> <input type="text" class="form-control" id="lname" /> </div> </div> <div class="form-group" data-form-group-type="radio-group"> <label>Gender:</label> <span class="control-value"></span> <button type="button" class="btn btn-default btn-sm" onclick="openModalEdit(this)"> <span class="glyphicon glyphicon-pencil"></span> Edit </button> <div class="control" hidden> <label class="radio-inline"> <input type="radio" name="gender" checked value="Male" />Male</label> <label class="radio-inline"> <input type="radio" name="gender" value="Female" />Female</label> </div> </div> </div> <hr /> </div> <div class="section" id="job_info"> <h4>Job information and skills:</h4> <span class="control-value"></span> <div class="form-group-fields"> <div class="form-group" data-form-group-type="select-input"> <label for="job">Job title</label> <span class="control-value"></span> <button type="button" class="btn btn-default btn-sm" onclick="openModalEdit(this)"> <span class="glyphicon glyphicon-pencil"></span> Edit </button> <div class="control" hidden> <select class="form-control" id="job"> <option>QA</option> <option>Developer</option> <option>Automation QA</option> <option>UI/UX Desing</option> </select> </div> </div> <div id="programming-languages" class="form-group" data-form-group-type="checkbox-group"> <label>Favourite programming languages:</label> <span class="control-value"></span> <button type="button" class="btn btn-default btn-sm" onclick="openModalEdit(this)"> <span class="glyphicon glyphicon-pencil"></span> Edit </button> <div class="control" hidden> <label class="checkbox-inline"> <input type="checkbox" value="C#" />C#</label> <label class="checkbox-inline"> <input type="checkbox" value="Java" />Java</label> <label class="checkbox-inline"> <input type="checkbox" value="JavaScript" />Javascript</label> <label class="checkbox-inline"> <input type="checkbox" value="Python" />Python</label> </div> </div> <div id="auto-tools" class="form-group" data-form-group-type="checkbox-group"> <label>Favourite automation tools:</label> <span class="control-value"></span> <button type="button" class="btn btn-default btn-sm" onclick="openModalEdit(this)"> <span class="glyphicon glyphicon-pencil"></span> Edit </button> <div class="control" hidden> <label class="checkbox-inline"> <input type="checkbox" value="Selenium" />Selenium</label> <label class="checkbox-inline"> <input type="checkbox" value="Cypress" />Cypress</label> <label class="checkbox-inline"> <input type="checkbox" value="Protractor" />Protractor</label> <label class="checkbox-inline"> <input type="checkbox" value="Katalon" />Katalon</label> </div> </div> <div id="english" class="form-group" data-form-group-type="slider-input"> <label>English (language proficiency):</label> <span class="control-value"></span> <button type="button" class="btn btn-default btn-sm" onclick="openModalEdit(this)"> <span class="glyphicon glyphicon-pencil"></span> Edit </button> <div class="control" hidden> <input style="width: 100px;" type="range" min="1" max="100" value="50" /> </div> </div> <div class="form-group" data-form-group-type="text-input-long"> <label for="comment">Career aspirations:</label> <span class="control-value"></span> <button type="button" class="btn btn-default btn-sm" onclick="openModalEdit(this)"> <span class="glyphicon glyphicon-pencil"></span> Edit </button> <div class="control" hidden> <textarea class="form-control" rows="5" id="comment"></textarea> </div> </div> </div> <hr /> </div> </form> <div id="footer"> </div> </div >';

function submitData() {
    var employeeData = getEmployeeData();
    document.getElementById('register').remove();
    document.body.innerHTML = newHtmlContainer;
    alert('Successfully registered an user!');
    setEmployeeData(employeeData);
}
function setEmployeeData(employeeData) {
    setFirstName(employeeData.firstName);
    setLastName(employeeData.lastName)
    setGender(employeeData.gender);
    setTechnologies(employeeData.technologies);
    setTools(employeeData.tools);
    setEnglish(employeeData.english);
    setJob(employeeData.job);
    setNotes(employeeData.careerNotes);
}

function setFirstName(employeeDataFirstName) {
    var firstName = document.getElementById('fname');
    firstName.value = employeeDataFirstName;
    getControlSpan(firstName).innerHTML = '';
    getControlSpan(firstName).appendChild(document.createTextNode(employeeDataFirstName));
}

function setLastName(employeeDataLastName) {
    var lastName = document.getElementById('lname');
    lastName.value = employeeDataLastName;
    getControlSpan(lastName).innerHTML = '';
    getControlSpan(lastName).appendChild(document.createTextNode(employeeDataLastName));
}

function setGender(employeeDataGender) {
    var radioButton = document.querySelector('input[name=gender][value=' + employeeDataGender + ']');
    getBooleanControlSpan(radioButton).innerHTML = '';
    getBooleanControlSpan(radioButton).appendChild(document.createTextNode(employeeDataGender));
    radioButton.setAttribute('checked', '');
}

function setTechnologies(employeeDataTechnologies) {
    for (var technology of employeeDataTechnologies) {
        document.querySelector('#programming-languages input[type=checkbox][value=\'' + technology + '\']').checked = true;
    }
    getBooleanControlSpan(document.querySelector('#programming-languages input[type=checkbox]')).innerHTML = '';
    getBooleanControlSpan(document.querySelector('#programming-languages input[type=checkbox]')).appendChild(document.createTextNode(employeeDataTechnologies));
}

function setTools(employeeDataTools) {
    for (var tool of employeeDataTools) {
        document.querySelector('#auto-tools input[type=checkbox][value=\'' + tool + '\']').checked = true;
    }
    getBooleanControlSpan(document.querySelector('#auto-tools input[type=checkbox]')).innerHTML = '';
    getBooleanControlSpan(document.querySelector('#auto-tools input[type=checkbox]')).appendChild(document.createTextNode(employeeDataTools));
}

function setEnglish(employeeDataEnglish) {
    var english = document.querySelector('#english input');
    getControlSpan(english).innerHTML = '';
    getControlSpan(english).appendChild(document.createTextNode(employeeDataEnglish));
    english.setAttribute('value', employeeDataEnglish);
}

function setJob(employeeDataJob) {
    var job = document.getElementById('job');
    getControlSpan(job).innerHTML = '';
    getControlSpan(job).appendChild(document.createTextNode(employeeDataJob));
    job.setAttribute('value', employeeDataJob);
}

function setNotes(employeeDataCareerNotes) {
    var notes = document.getElementById('comment');
    getControlSpan(notes).innerHTML = '';
    getControlSpan(notes).appendChild(document.createTextNode(employeeDataCareerNotes));
    notes.setAttribute('value', employeeDataCareerNotes);
}

function getControlSpan(element) {
    return element.parentElement.parentElement.querySelector('span.control-value');
}

function getBooleanControlSpan(element) {
    return element.parentElement.parentElement.parentElement.querySelector('span.control-value');
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







function openModalEdit(element) {
    var parent = element.parentElement;
    var name = parent.getAttribute('name');
    var id = parent.getAttribute('id');
    var type = parent.getAttribute('data-form-group-type');
    var control = parent.getElementsByClassName('control')[0];
    var modal = createModal(control, name, type, id);
    parent.appendChild(modal);
    var button = parent.querySelector('button.btn.btn-default.btn-sm');
    button.setAttribute('disabled', '');
}
function createModal(control, name, type, id) {
    var modal = document.createElement('div');
    modal.setAttribute('class', 'modal-content');

    var header = createHeader();

    var body = document.createElement('div');
    body.setAttribute('class', 'modal-body');
    var formGroup = createControl(control, name, type, id);
    body.appendChild(formGroup);

    var footer = createFooter();

    modal.appendChild(header);
    modal.appendChild(body);
    modal.appendChild(footer);
    return modal;
}

function createFooter() {
    var footer = document.createElement('div');
    footer.setAttribute('class', 'modal-footer');
    var okBtn = document.createElement('button');
    okBtn.setAttribute('type', 'button');
    okBtn.setAttribute('class', 'btn btn-primary');
    okBtn.innerHTML = 'Ok';
    okBtn.setAttribute('onclick', 'saveCotrol(this)');

    var cancelBtn = document.createElement('button');
    cancelBtn.setAttribute('type', 'button');
    cancelBtn.setAttribute('class', 'btn btn-danger');
    cancelBtn.innerHTML = 'Cancel';
    cancelBtn.setAttribute('onclick', 'dismissModal(this)');

    footer.appendChild(okBtn);
    footer.appendChild(cancelBtn);
    return footer;
}

function saveCotrol(element) {
    var modal = element.parentElement.parentElement;
    var control = modal.getElementsByClassName('control')[0];

    dismissModal(element);

    if (control.querySelector('#fname') != null) {
        setFirstName(getEmployeeDataFirstName());
    }

    if (control.querySelector('#lname') != null) {
        setLastName(getEmployeeDataLastName());
    }

    if (control.querySelector('.radio-inline') != null) {
        setGender(getGender());
    }

    if (control.querySelector('select') != null) {
        setJob(getJob());
    }

    if (control.querySelector('input[value=Java]') != null) {
        setTechnologies(getContextTechArray());
    }

    if (control.querySelector('input[value=Selenium]') != null) {
        setTools(getToolsArray());
    }

    if (control.querySelector('input[type=range]') != null) {
        setEnglish(getEnglish());
    }

    if (control.querySelector('textarea') != null) {
        setNotes(getNotes());
    }

}

function dismissModal(element) {
    var modal = element.parentElement.parentElement;
    var formControl = modal.parentElement;
    var control = modal.getElementsByClassName('control')[0];
    formControl.appendChild(control);
    control.setAttribute('hidden', '');
    modal.remove();
    var button = formControl.querySelector('button.btn.btn-default.btn-sm');
    button.removeAttribute('disabled');
}

function createHeader() {
    var header = document.createElement('div');
    header.setAttribute('class', 'modal-header');
    var closeButton = document.createElement('button');
    closeButton.setAttribute('type', 'button'); closeButton.setAttribute('class', 'close'); closeButton.setAttribute('data-dismiss', 'modal'); closeButton.innerHTML = '&times;';
    var h4 = document.createElement('h4');
    h4.setAttribute('class', 'modal-title');
    h4.innerHTML = 'Edit Field';
    header.appendChild(h4);
    return header;
}

function createControl(control, name, type, id) {
    var formGroup = document.createElement('div');
    formGroup.setAttribute('class', 'form-group'); formGroup.setAttribute('data-forom-group-type', type);
    var label = document.createElement('label');
    label.setAttribute('for', id);
    label.innerHTML = name;
    formGroup.appendChild(label);
    control.removeAttribute('hidden');
    formGroup.appendChild(control);

    return formGroup;
}