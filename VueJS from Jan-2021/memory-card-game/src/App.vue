<template>
  <div id="app">

    <div class="controls">
      <button class="btn" 
              @click="onGameStart" 
              :disabled="isGameStarted">
              Start new game
      </button>
      <button class="btn" 
              @click="handleGameReset" 
              :disabled="!isGameStarted">
              Reset game
      </button>
      <span class="counter">TIME LEFT: {{counter}}</span>
    </div>

    <div class="results" v-if="stopGame">
      <p v-if="areAllFound" class="win"> YOU WIN :)</p>
      <p v-else class="fail"> YOU Fail.</p>
    </div>

    <ul class="memory-game">
      <li v-for="(card, index) in shuffleCards" 
          :key="index"
          class="memory-card"
          :class="{ flip: card.visible, 'disable-card': card.matched }"
          :data-framework="card.name"
          @click="onCardClick(card, index)">

          <img class="front-face" svg-inline :src="card.image" :alt="card.name" />
          <img class="back-face" src="./assets/img/js-badge.svg" :alt="card.name" />
      </li>
    </ul>

  </div>
</template>

<script>
const timerSeconds = 60;
let interval;

export default {
  name:"App",
  data() {
    return {
      isGameStarted: false,
      stopGame: false,
      counter: timerSeconds,
      correctPairNumber: 0,
      selected: [],
      shuffleCards: [],
      cards: [
        {
          name: "react",
          image: require("./assets/img/react.svg"),
          visible: false,
          matched: false,
        },
        {
          name: "angular",
          image: require("./assets/img/angular.svg"),
          visible: false,
          matched: false,
        },
        {
          name: "aurelia",
          image: require("./assets/img/aurelia.svg"),
          visible: false,
          matched: false,
        },
        {
          name: "backbone",
          image: require("./assets/img/backbone.svg"),
          visible: false,
          matched: false,
        },
        {
          name: "ember",
          image: require("./assets/img/ember.svg"),
          visible: false,
          matched: false,
        },
        {
          name: "vue",
          image: require("./assets/img/vue.svg"),
          visible: false,
          matched: false,
        },
      ]
    };
  },
  watch: {
    selected(newValue) {
      if(newValue.length === 2) {
        const [firstCardIndex, secondCardIndex] = newValue;
        const firstCard = this.shuffleCards[firstCardIndex];
        const secondCard = this.shuffleCards[secondCardIndex];

        if(firstCard.name === secondCard.name) {
          firstCard.matched = true;
          secondCard.matched = true;
          this.correctPairNumber++;
        } else {
          setTimeout(() => {
            firstCard.visible = false;
            secondCard.visible = false;
          }, 2000);
        }

        this.selected = [];
      }
    },
    counter(newValue) {
      if(newValue == 0) {
        this.clearTimer();
        this.handleGameEnd();
      }
    },
    areAllFound(newValue, oldValue) {
      if(newValue != oldValue && newValue) {
        this.handleFinishedGame();
      }
    }
  },
  computed: {
    areAllFound() {
      return this.cards.length == this.correctPairNumber;
    }
  },
  methods: {
    shuffle(cardsArray) {
      let currentIndex = cardsArray.length, 
        temporaryValue, 
        randomIndex;

      while(0 != currentIndex) {
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex--;

        temporaryValue = cardsArray[currentIndex];
        cardsArray[currentIndex] = cardsArray[randomIndex];
        cardsArray[randomIndex] = temporaryValue;
      }

      return cardsArray;
    },
    generateShuffleCards() {
      const cards = [
        ...JSON.parse(JSON.stringify(this.cards)),
        ...JSON.parse(JSON.stringify(this.cards))
      ]; //Това прави два пъти дълбоко копие на масива.
      this.shuffle(cards);
      this.shuffleCards = cards;
    },
    onCardClick(card, index) {
      card.visible = !card.visible;
      this.selected.push(index);
    },
    startCounter() {
      interval = setInterval(() => {
        this.counter--;
      }, 1000);
    },
    onGameStart() {
      this.isGameStarted = true;
      this.resetState();
      this.generateShuffleCards();
      this.startCounter();
    },
    clearTimer() {
      clearInterval(interval);
    },
    handleGameEnd() {
      this.stopGame = true;
      this.isGameStarted = false;
      if(!this.areAllFound) {
        this.shuffleCards.forEach(card => card.matched = true);
      }
    },
    resetState() {
      this.counter = timerSeconds;
      this.correctPairNumber = 0;
      this.shuffleCards = [];
      this.stopGame = false;
    },
    handleGameReset() {
      this.clearTimer();
      this.resetState();
      this.isGameStarted = false;
    },
    handleFinishedGame() {
      this.clearTimer();
      this.handleGameEnd();
    }
  }
}
</script>

<style>
.heading {
  font-size: 1rem;
  font-weight: bold;
  text-align: center;
  margin-bottom: 1rem;
}
* {
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}
ul {
  padding: 0;
  margin: 0;
}
li {
  list-style: none;
}
body {
  height: 100vh;
  display: flex;
  background-image: linear-gradient(120deg, #d4fc79 0%, #96e6a1 100%);
}
#app {
  width: 100%;
  padding: 7%;
}
.controls {
  width: 640px;
  margin: 0 auto 30px auto;
  display: flex;
  align-items: center;
}
.controls .btn {
  border: 1px solid #34495e;
  font-size: 16px;
  padding: 8px 12px;
  border-radius: 5px;
  background-color: #41b883;
  color: #34495e;
  font-weight: bold;
  cursor: pointer;
}
.controls .btn:first-child {
  margin-right: 16px;
}
.controls .counter {
  font-size: 21px;
  margin-left: auto;
  font-weight: bold;
  color: #34495e;
}
.results {
  width: 640px;
  margin: 0 auto 30px auto;
  font-size: 28px;
  font-weight: bold;
  text-align: center;
  color: #1d1d35;
}
.results .win,
.results .fail {
  padding: 12px 0;
  border-radius: 12px;
}
.results .win {
  background-color: #4fa4ff;
}
.results .fail {
  background-color: #ff7c5f;
}
.memory-game {
  width: 640px;
  height: 640px;
  margin: auto;
  display: flex;
  flex-wrap: wrap;
  perspective: 1000px;
}
.memory-card {
  width: calc(25% - 10px);
  height: calc(33.333% - 10px);
  margin: 5px;
  position: relative;
  transform: scale(1);
  transform-style: preserve-3d;
  transition: transform 0.5s;
  box-shadow: 1px 1px 1px rgba(0, 0, 0, 0.3);
  cursor: pointer;
}
.disable-card {
  pointer-events: none;
}
.memory-card:active {
  transform: scale(0.97);
  transition: transform 0.2s;
}
.memory-card.flip {
  transform: rotateY(180deg);
}
.front-face,
.back-face {
  width: 100%;
  height: 100%;
  padding: 20px;
  position: absolute;
  border-radius: 5px;
  background: #fff29e;
  backface-visibility: hidden;
}
.front-face {
  transform: rotateY(180deg);
}
</style>
