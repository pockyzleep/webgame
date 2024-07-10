let promptSeq = [];
let userSeq = [];
let level = 0;
let canClick = false;

// launch game
function startGame() {
    promptSeq = [];
    userSeq = [];
    level = 0;
    document.getElementById('start-button').disabled = true;
    document.getElementById('status').textContent = "";
    updateScoreboard();
    nextLevel();
}

// RNG cell given from 0 - 8 (3x3 grid)
function getRandomCell() {
    return Math.floor(Math.random() * 9);
}

// light up cell given moment of time
function flashCell(cell) {
    cell.classList.add('active');
    setTimeout(() => {
        cell.classList.remove('active');
    }, 500);
}

// advance to next level
function nextLevel() {
    level++;
    userSeq = [];
    canClick = false;
    promptSeq.push(getRandomCell());
    updateScoreboard();
    showSequence();
}

// update the scoreboard
function updateScoreboard() {
    document.getElementById('scoreboard').textContent = `Level: ${level}`;
}

// display current sequence
function showSequence() {
    promptSeq.forEach((cellIndex, index) => {
        setTimeout(() => {
            flashCell(document.getElementById(`cell-${cellIndex}`));
        }, (index + 1) * 800);
    });
    setTimeout(() => {
        canClick = true;
    }, promptSeq.length * 800);
}

// handle clicking
function cellClicked(cellIndex) {
    if (!canClick) return;

    userSeq.push(cellIndex);
    flashCell(document.getElementById(`cell-${cellIndex}`));

    if (userSeq[userSeq.length - 1] !== promptSeq[userSeq.length - 1]) {
        document.getElementById('status').innerHTML = `<br>Game over! Completed until level ${level}`;
        document.getElementById('start-button').disabled = false;
        return;
    }

    if (userSeq.length === promptSeq.length) {
        setTimeout(() => {
            nextLevel();
        }, 1000);
    }
}

// event listeners for each cell
document.querySelectorAll('.grid-item').forEach((cell, index) => {
    cell.addEventListener('click', () => {
        cellClicked(index);
    });
});

// theme toggler
function toggleTheme() {
    const body = document.body;
    const themeToggle = document.getElementById('theme-toggle');
    if (body.classList.contains('dark-mode')) {
        body.classList.remove('dark-mode');
        body.classList.add('light-mode');
        themeToggle.textContent = "Light";
    } else {
        body.classList.remove('light-mode');
        body.classList.add('dark-mode');
        themeToggle.textContent = "Dark";
    }
}
