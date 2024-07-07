const gameContainer = document.querySelector(".container"),
userResult = document.querySelector(".user_result img"),
botResult = document.querySelector(".bot_result img"),
result = document.querySelector(".result"),
optionImages = document.querySelectorAll(".option_image");

//Loop t hrough each option image element
optionImages.forEach((image,index) => {
    image.addEventListener("click", (e) => {
        image.classList.add("active");

        //Loop through each option image again
        optionImages.forEach((image2,index2) => {
          //If current index doesn't match the clicked index
          //Remove the "active" class from the other option images
          index !== index2 && image2.classList.remove("active");

        })
        //Get source of the clicked option image
        let imageSrc = e.target.querySelector("img").src;
        //Set the user image to the clicked option image
        userResult.src = imageSrc;
        
        //Generate a random number between 0 and 4
        let randomNumer = Math.floor(Math.random() * 5);
        console.log(randomNumer);

        //Create an array of Bot image option
        let botImages = ["choices/rock.png", "choices/scissors.png", "choices/spock.png", "choices/paper.png", "choices/lizard.png"]
        botResult.src = botImages[randomNumer];

        let botValue = ["R", "Sc", "Sp", "P", "L"][randomNumer];

        let userValue = ["R", "Sc", "Sp", "P", "L"][index];

        //Creat an object with all possible outcomes
        let outcomes = {
            RR: "Draw",
            ScSc: "Draw",
            SpSp: "Draw",
            PP: "Draw",
            LL: "Draw",
            RSc: "User",
            RSp: "Bot",
            RP: "Bot",
            RL: "User",
            ScR:"Bot",
            ScSp: "Bot",
            ScP: "User",
            ScL: "User",
            SpR: "Bot",
            SpSc: "Bot",
            SpP: "User",
            SpL: "User",
            PR: "User",
            PSc: "Bot",
            PSp: "User",
            PL: "Bot",
            LR: "Bot",
            LSc: "Bot",
            LSp: "User",
            LP: "User",
        };

        //Look up the outcome value based on user and CPU options
        let outComeValue = outcomes[userValue + botValue];

        //Display result
        result.textContent = userValue === botValue ? "Match Draw" : `${outComeValue} Won`;
        console.log(outComeValue);
    })
})