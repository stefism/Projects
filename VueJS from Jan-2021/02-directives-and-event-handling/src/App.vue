<template>
  <div id="app">
    <h1 @mouseenter="showTime" @mouseleave="hideTime">Time is?</h1>
    <p v-if="isVisible">Current time {{time}}</p>
  </div>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      time: '',
      isVisible: false
    };
  },
  methods: {
    showTime() {
      const date = new Date();
      
      // const options = {
      //   weekday: 'long',
      //   year: 'numeric',
      //   month: 'numeric',
      //   day: 'numeric',
      //   hour: 'numeric',
      //   minute: 'numeric',
      //   second: 'numeric'
      // };

      // const formattedDate = new Intl.DateTimeFormat('bg', options).format(date);
      // this.time = formattedDate;

      this.time = date.toLocaleString('bg'); //Или ето така за по-кратко. Замества горното писане.
      
      this.isVisible = true;
    },

    hideTime() {
      this.time = '';
      this.isVisible = false;
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
