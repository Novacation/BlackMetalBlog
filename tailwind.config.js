/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./Pages/**/*.cshtml", "./Views/**/*.cshtml", './wwwroot/**/*.js'],
  theme: {
    extend: {},
  },
  plugins: [
      require("daisyui")
  ],
  daisyui: {
    themes: ["dark"],
  },
};
