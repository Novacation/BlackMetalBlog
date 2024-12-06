const path = require("path");

module.exports = {
    entry: {
        login: "./wwwroot/js/Auth/login.js",
        register: "./wwwroot/js/Auth/register.js",
    },
    output: {
        filename: "[name].bundle.js",
        path: path.resolve(__dirname, "wwwroot/dist"),
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader",
                    options: {
                        presets: [
                            [
                                "@babel/preset-env",
                                {
                                    targets: {
                                        chrome: "65",
                                        edge: "16",
                                        firefox: "58",
                                        ie: "11",
                                    },
                                    useBuiltIns: "usage",
                                    corejs: 3,
                                    modules: false,
                                },
                            ],
                        ],
                    },
                },
            },
        ],
    },
};
