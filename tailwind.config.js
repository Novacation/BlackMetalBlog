/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './Views/**/*.cshtml',
        './Pages/**/*.cshtml',
        './wwwroot/**/*.html',
        './wwwroot/**/*.js',
        "./node_modules/flowbite/**/*.js"
    ],

    theme: {
        extend: {
            // You can extend Tailwind's default theme here
        },
    },
    plugins: [
        // Add any Tailwind plugins you might use here
        require('flowbite/plugin')
    ],
}
