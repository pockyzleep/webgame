function checkWin() {
    // To check what is the contents of each box
    var top_left, top_middle, top_right, center_left, center_middle, 
        center_right, bottom_left, bottom_middle, bottom_right
    top_left        =   document.getElementById("top_left").value;
    top_middle      =   document.getElementById("top_middle").value;
    top_right       =   document.getElementById("top_right").value;
    center_left     =   document.getElementById("center_left").value;
    center_middle   =   document.getElementById("center_middle").value;
    center_right    =   document.getElementById("center_right").value;
    bottom_left     =   document.getElementById("bottom_left").value;
    bottom_middle   =   document.getElementById("bottom_middle").value;
    bottom_right    =   document.getElementById("bottom_right").value;

    // To get each individual box for css modification
    var top_left_box, top_middle_box, top_right_box, center_left_box, center_middle_box, 
    center_right_box, bottom_left_box, bottom_middle_box, bottom_right_box

    top_left_box        =   document.getElementById("top_left");
    top_middle_box      =   document.getElementById("top_middle");
    top_right_box       =   document.getElementById("top_right");
    center_left_box     =   document.getElementById("center_left");
    center_middle_box   =   document.getElementById("center_middle");
    center_right_box    =   document.getElementById("center_right");
    bottom_left_box     =   document.getElementById("bottom_left");
    bottom_middle_box   =   document.getElementById("bottom_middle");
    bottom_right_box    =   document.getElementById("bottom_right");

    var grid = [top_left_box, top_middle_box, top_right_box, center_left_box, center_middle_box, 
        center_right_box, bottom_left_box, bottom_middle_box, bottom_right_box]

    function winX() {
        grid.forEach(element => {
            element.disabled = true;
        });
        document.getElementById("result").textContent="Winner: X";
    }
    
    function winO() {
        grid.forEach(element => {
            element.disabled = true;
        });
        document.getElementById("result").textContent="Winner: O";
    }
        
    // Top Row Win Check
    if (top_left == 'X' && top_middle == 'X' && top_right == 'X') {
        top_left_box.style.color = "red";
        top_middle_box.style.color = "red";
        top_right_box.style.color = "red";
        winX();
    } else if (top_left == 'O' && top_middle == 'O' && top_right == 'O') {
        top_left_box.style.color = "red";
        top_middle_box.style.color = "red";
        top_right_box.style.color = "red";
        winO();
    // Center Row Win Check
    } else if (center_left == 'X' && center_middle == 'X' && center_right == 'X') {
        center_left_box.style.color = "red";
        center_middle_box.style.color = "red";
        center_right_box.style.color = "red";
        winX();
    } else if (center_left == 'O' && center_middle == 'O' && center_right == 'O') {
        center_left_box.style.color = "red";
        center_middle_box.style.color = "red";
        center_right_box.style.color = "red";
        winO();
    // Bottom Row Win Check
    } else if (bottom_left == 'X' && bottom_middle == 'X' && bottom_right == 'X') {
        bottom_left_box.style.color = "red";
        bottom_middle_box.style.color = "red";
        bottom_right_box.style.color = "red";        
        winX();
    } else if (bottom_left == 'O' && bottom_middle == 'O' && bottom_right == 'O') {
        bottom_left_box.style.color = "red";
        bottom_middle_box.style.color = "red";
        bottom_right_box.style.color = "red";
        winO();
    // Left Column Win Check
    } else if (top_left == 'X' && center_left == 'X' && bottom_left == 'X') {
        top_left_box.style.color = "red";
        center_left_box.style.color = "red";
        bottom_left_box.style.color = "red";
        winX();
    } else if (top_left == 'O' && center_left == 'O' && bottom_left == 'O') {
        top_left_box.style.color = "red";
        center_left_box.style.color = "red";
        bottom_left_box.style.color = "red";
        winO();
    // Middle Column Win Check
    } else if (top_middle == 'X' && center_middle == 'X' && bottom_middle == 'X') {
        top_middle_box.style.color = "red";
        center_middle_box.style.color = "red";
        bottom_middle_box.style.color = "red";
        winX();
    } else if (top_middle == 'O' && center_middle == 'O' && bottom_middle == 'O') {
        top_middle_box.style.color = "red";
        center_middle_box.style.color = "red";
        bottom_middle_box.style.color = "red";
        winO();
    // Right Column Win Check
    } else if (top_right == 'X' && center_right == 'X' && bottom_right == 'X') {
        top_right_box.style.color = "red";
        center_right_box.style.color = "red";
        bottom_right_box.style.color = "red";
        winX();
    } else if (top_right == 'O' && center_right == 'O' && bottom_right == 'O') {
        top_right_box.style.color = "red";
        center_right_box.style.color = "red";
        bottom_right_box.style.color = "red";
        winO();
    // Down Left Diagonal Check
    } else if (top_left == 'X' && center_middle == 'X' && bottom_right == 'X') {
        top_left_box.style.color = "red";
        center_middle_box.style.color = "red";
        bottom_right_box.style.color = "red";
        winX();
    } else if (top_left == 'O' && center_middle == 'O' && bottom_right == 'O') {
        top_left_box.style.color = "red";
        center_middle_box.style.color = "red";
        bottom_right_box.style.color = "red";
        winO();
    // Up Right Diagonal Check
    } else if (top_right == 'X' && center_middle == 'X' && bottom_left == 'X') {
        top_right_box.style.color = "red";
        center_middle_box.style.color = "red";
        bottom_left_box.style.color = "red";
        winX();
    } else if (top_right == 'O' && center_middle == 'O' && bottom_left == 'O') {
        top_right_box.style.color = "red";
        center_middle_box.style.color = "red";
        bottom_left_box.style.color = "red";
        winO();
    // Tie Condition Check
    } else if (top_left_box.disabled == true && top_middle_box.disabled == true &&
        top_right_box.disabled == true && center_left_box.disabled == true && 
        center_middle_box.disabled == true && center_right_box.disabled == true &&
        bottom_left_box.disabled == true && bottom_middle_box.disabled == true &&
        bottom_right_box.disabled == true) {
        grid.forEach(element => {
            element.style.color = "rgba(190, 196, 190, 0.637)";
            element.style.opacity = "0.85";
        });
        document.getElementById("result").textContent = "It's a Draw!";
    }
}

// If turn = 1, then it is X's turn, otherwise if it's 0, then it's O's turn
turn = 1;


function top_left_action() {
    if (turn == 1) {
        document.getElementById("top_left").value = "X";
        document.getElementById("top_left").disabled = true;
        turn = 0;
    } else {
        document.getElementById("top_left").value = "O";
        document.getElementById("top_left").disabled = true;
        turn = 1;
    }
}

function top_middle_action() {
    if (turn == 1) {
        document.getElementById("top_middle").value = "X";
        document.getElementById("top_middle").disabled = true;
        turn = 0;
    } else {
        document.getElementById("top_middle").value = "O";
        document.getElementById("top_middle").disabled = true;
        turn = 1;
    }
}

function top_right_action() {
    if (turn == 1) {
        document.getElementById("top_right").value = "X";
        document.getElementById("top_right").disabled = true;
        turn = 0;
    } else {
        document.getElementById("top_right").value = "O";
        document.getElementById("top_right").disabled = true;
        turn = 1;
    }
}

function center_left_action() {
    if (turn == 1) {
        document.getElementById("center_left").value = "X";
        document.getElementById("center_left").disabled = true;
        turn = 0;
    } else {
        document.getElementById("center_left").value = "O";
        document.getElementById("center_left").disabled = true;
        turn = 1;
    }
}

function center_middle_action() {
    if (turn == 1) {
        document.getElementById("center_middle").value = "X";
        document.getElementById("center_middle").disabled = true;
        turn = 0;
    } else {
        document.getElementById("center_middle").value = "O";
        document.getElementById("center_middle").disabled = true;
        turn = 1;
    }
}

function center_right_action() {
    if (turn == 1) {
        document.getElementById("center_right").value = "X";
        document.getElementById("center_right").disabled = true;
        turn = 0;
    } else {
        document.getElementById("center_right").value = "O";
        document.getElementById("center_right").disabled = true;
        turn = 1;
    }
}

function bottom_left_action() {
    if (turn == 1) {
        document.getElementById("bottom_left").value = "X";
        document.getElementById("bottom_left").disabled = true;
        turn = 0;
    } else {
        document.getElementById("bottom_left").value = "O";
        document.getElementById("bottom_left").disabled = true;
        turn = 1;
    }
}

function bottom_middle_action() {
    if (turn == 1) {
        document.getElementById("bottom_middle").value = "X";
        document.getElementById("bottom_middle").disabled = true;
        turn = 0;
    } else {
        document.getElementById("bottom_middle").value = "O";
        document.getElementById("bottom_middle").disabled = true;
        turn = 1;
    }
}

function bottom_right_action() {
    if (turn == 1) {
        document.getElementById("bottom_right").value = "X";
        document.getElementById("bottom_right").disabled = true;
        turn = 0;
    } else {
        document.getElementById("bottom_right").value = "O";
        document.getElementById("bottom_right").disabled = true;
        turn = 1;
    }
}

function resetBoard() {
    location.reload();
}