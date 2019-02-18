<template>
    <div>
      <section>
        <b-field label="Title">
            <b-input></b-input>
        </b-field>
        <b-field label="Slide Text">
            <b-input maxlength="1000" type="textarea"></b-input>
        </b-field>
      </section>
    </div>
</template>

<script>
export default {
  name: 'AddTextSlide'
}
</script>

<style scoped>

</style>
