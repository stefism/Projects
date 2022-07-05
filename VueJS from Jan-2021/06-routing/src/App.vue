<template>
  <div id="app">
    <Navigation />
    <Home />
  </div>
</template>

<script>
import Home from "@/views/Home-page.vue";
import Navigation from "@/components/Navigation-comp.vue";
export default {
  name: "App",
  components: {
    Home,
    Navigation,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>