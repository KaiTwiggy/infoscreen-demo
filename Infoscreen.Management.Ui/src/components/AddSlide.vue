<template>
  <div class="container">
    <form id="addSlideForm" ref="addSlide">
      <section>
        <b-field label="Nimi">
          <b-input v-model="form.Title" placeholder="Nimi"></b-input>
        </b-field>
        <b-field label="Tyyppi">
          <b-select v-model="form.Type" placeholder="Tyyppi" expanded v-on:input="updateTypeValue($event)">
            <option value="Text">Teksti</option>
            <option value="Image">Kuva</option>
          </b-select>
        </b-field>
      </section>
      <br/>

      <h1 v-if="typeValue !== ''">Slide data</h1>

      <div v-if="typeValue === 'Text'">
      <section>
        <b-field label="Title">
            <b-input v-model="form.slideData['Text'].title"></b-input>
        </b-field>
        <b-field label="Slide Text">
            <b-input v-model="form.slideData['Text'].text" maxlength="1000" type="textarea"></b-input>
        </b-field>
      </section>
      </div>
      <div v-if="typeValue === 'Image'">
        <section>
          <b-field label="Image Url">
              <b-input v-model="form.slideData['Image'].src"></b-input>
          </b-field>
        </section>
      </div>
    </form>
    <br/>

    <div v-if="typeValue !== ''" class="container has-text-centered">
      <a class="button is-primary is-medium" @click='sendForm'>Add Slide</a>
    </div>
  </div>
</template>

<script>
import AddTextSlide from './AddTextSlide'
import AddImageSlide from './AddImageSlide'
import axios from 'axios'
import * as constants from '../constants'

var typeValue = ''
var formData = {
  Title: '',
  Type: typeValue,
  slideData: {}
}

formData.slideData['Text'] = { text: '', title: '' }
formData.slideData['Image'] = { src: '' }

export default {
  components: { AddTextSlide, AddImageSlide },
  name: 'AddSlide',
  data: function () {
    return {
      typeValue,
      form: formData
    }
  },
  methods: {
    updateTypeValue: function (value) {
      this.typeValue = value
    },
    sendForm: function () {
      var data = {
        cardType: formData.Type + 'Slide',
        isActive: false,
        isDeleted: false,
        name: formData.Title,
        data: formData.slideData[formData.Type]
      }

      axios.post(constants.API_BASEURL + '/api/Slide', data)
    }
  },
  created () {}
}
</script>

<style scoped>

</style>
