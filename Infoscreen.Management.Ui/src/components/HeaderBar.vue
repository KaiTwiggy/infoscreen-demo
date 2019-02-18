<template>
  <div class="container">
     <div id="navbarExampleTransparentExample" class="navbar-menu">
    <div class="navbar-start">
      <a class="navbar-item" @click='navigate("FrontPage")' href="#">Home</a>
      <a class="navbar-item" @click='navigate("AddSlide")' href="#">Add Slide</a>
      <a class="navbar-item" @click='navigate("DeviceList")' href="#">Devices</a>
    </div>
  </div>
  </div>
</template>

<script>
export default {
  name: 'HeaderBar',
  props: ['router'],
  methods: {
    navigate: function (name) {
      this.$router.push({ name })
    }
  }
}
</script>

<style scoped>
h1,
h2 {
  font-weight: normal;
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
