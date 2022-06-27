<template>
  <div>
    <h1>Dynamic component 1</h1>
    <form>
      First name:<br />
      <input type="text" name="firstname" /><br />
      Last name:<br />
      <input type="text" name="lastname" />
    </form>
  </div>
</template>

<script>
export default {
  name: "DynamicComp1",
  props: {
    msg: String,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
