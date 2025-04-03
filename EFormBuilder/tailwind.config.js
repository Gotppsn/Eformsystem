// Path: EFormBuilder/tailwind.config.js

module.exports = {
    content: [
      './**/*.{razor,html,cshtml}',
      './Components/**/*.{razor,html,cshtml}',
      './Pages/**/*.{razor,html,cshtml}',
      './Shared/**/*.{razor,html,cshtml}'
    ],
    theme: {
      extend: {
        colors: {
          'primary': '#3b82f6',
          'primary-dark': '#2563eb',
          'secondary': '#6b7280',
          'success': '#10b981',
          'danger': '#ef4444',
          'warning': '#f59e0b',
          'info': '#3b82f6'
        },
        spacing: {
          '72': '18rem',
          '84': '21rem',
          '96': '24rem',
        },
        borderRadius: {
          'xl': '1rem',
          '2xl': '2rem',
        }
      },
    },
    plugins: [],
  }