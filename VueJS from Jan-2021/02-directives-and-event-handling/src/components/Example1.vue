<template>
  <div id="app">
    <h1>Conditional  Rendering</h1>
    <p v-if="isVisible">This text is visible</p>
    <!-- v-if - директва за условно показване/скриване. Вързана е долу с променливата със същото име и ако е true, параграфа се показва. Ако е false не се показва. -->

    <p v-else>Or not visible</p>
    <!-- v-else е вързано с v-if и все едно имаме if - else condition. -->

    <p v-show="isVisible">This text is show</p>
    <!-- Разликата между v-if и v-show е че v-if премахва елемента от дом дървото, а v-show не го премахва, а му набива динамично стил style="display: none;" -->

    <h2>else if example</h2>
    <p v-if="selectedNumber == 0">Nimber is 0</p>
    <p v-else-if="selectedNumber < 0">Nimber is negative</p>
    <p v-else>Nimber is positive</p>
  </div>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      isVisible: true,
      selectedNumber: 1
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>