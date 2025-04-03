class DragDropService {
    constructor() {
        this.draggedElement = null;
        this.draggedElementType = null;
        this.dragSourceElement = null;
        this.dropTargetElement = null;
        this.isDraggingFromPalette = false;
    }

    initialize() {
        this.setupDragAndDrop();
    }

    setupDragAndDrop() {
        // Set up drag start event for palette items
        const paletteItems = document.querySelectorAll('.form-element-item');
        paletteItems.forEach(item => {
            item.addEventListener('dragstart', this.handleDragStart.bind(this));
            item.addEventListener('dragend', this.handleDragEnd.bind(this));
        });

        // Set up drag and drop events for form builder container
        const formBuilderContainer = document.querySelector('.form-builder-container');
        if (formBuilderContainer) {
            formBuilderContainer.addEventListener('dragover', this.handleDragOver.bind(this));
            formBuilderContainer.addEventListener('drop', this.handleDrop.bind(this));
            formBuilderContainer.addEventListener('dragenter', this.handleDragEnter.bind(this));
            formBuilderContainer.addEventListener('dragleave', this.handleDragLeave.bind(this));
        }

        // Set up drag events for existing form elements
        const formElements = document.querySelectorAll('.form-builder-item');
        formElements.forEach(element => {
            element.addEventListener('dragstart', this.handleDragStart.bind(this));
            element.addEventListener('dragend', this.handleDragEnd.bind(this));
        });
    }

    handleDragStart(event) {
        this.draggedElement = event.target;
        this.dragSourceElement = event.target;
        
        // Check if dragging from palette
        this.isDraggingFromPalette = this.draggedElement.classList.contains('form-element-item');
        
        // Set the element type for new elements
        if (this.isDraggingFromPalette) {
            this.draggedElementType = this.draggedElement.getAttribute('data-element-type');
        }
        
        // Set data transfer
        event.dataTransfer.effectAllowed = 'move';
        event.dataTransfer.setData('text/plain', this.isDraggingFromPalette ? 
            this.draggedElementType : 
            this.draggedElement.getAttribute('data-element-id'));
        
        // Add dragging class
        this.draggedElement.classList.add('dragging');
        
        return true;
    }

    handleDragOver(event) {
        if (event.preventDefault) {
            event.preventDefault();
        }
        
        event.dataTransfer.dropEffect = 'move';
        
        return false;
    }

    handleDragEnter(event) {
        const target = this.findDropTarget(event.target);
        
        if (target && target !== this.draggedElement) {
            target.classList.add('drag-over');
            this.dropTargetElement = target;
        }
    }

    handleDragLeave(event) {
        const target = this.findDropTarget(event.target);
        
        if (target) {
            target.classList.remove('drag-over');
            
            if (this.dropTargetElement === target) {
                this.dropTargetElement = null;
            }
        }
    }

    handleDrop(event) {
        if (event.stopPropagation) {
            event.stopPropagation();
        }
        
        // Find the closest drop target
        const dropTarget = this.findDropTarget(event.target);
        
        if (!dropTarget) {
            return false;
        }
        
        // Remove drag-over class
        dropTarget.classList.remove('drag-over');
        
        // Handle drop based on source
        if (this.isDraggingFromPalette) {
            // Create a new element
            const elementType = event.dataTransfer.getData('text/plain');
            this.createNewElement(elementType, dropTarget);
        } else {
            // Reorder existing element
            const elementId = event.dataTransfer.getData('text/plain');
            this.reorderElement(elementId, dropTarget);
        }
        
        return false;
    }

    handleDragEnd(event) {
        // Remove dragging class
        this.draggedElement.classList.remove('dragging');
        
        // Clear references
        this.draggedElement = null;
        this.draggedElementType = null;
        this.dragSourceElement = null;
        this.dropTargetElement = null;
        this.isDraggingFromPalette = false;
        
        // Remove drag-over class from all elements
        const dragOverElements = document.querySelectorAll('.drag-over');
        dragOverElements.forEach(element => {
            element.classList.remove('drag-over');
        });
    }

    // Helper to find the closest drop target (form builder container or item)
    findDropTarget(element) {
        if (!element) return null;
        
        if (element.classList.contains('form-builder-container') || 
            element.classList.contains('form-builder-item')) {
            return element;
        }
        
        return this.findDropTarget(element.parentElement);
    }

    // Create new element based on type
    createNewElement(elementType, dropTarget) {
        // This would be called via Blazor interop in a real app
        const event = new CustomEvent('formelement:created', {
            detail: {
                elementType: elementType,
                targetId: dropTarget.getAttribute('data-element-id') || 'container'
            },
            bubbles: true
        });
        
        document.dispatchEvent(event);
    }

    // Reorder existing element
    reorderElement(elementId, dropTarget) {
        // This would be called via Blazor interop in a real app
        const event = new CustomEvent('formelement:reordered', {
            detail: {
                elementId: elementId,
                targetId: dropTarget.getAttribute('data-element-id') || 'container'
            },
            bubbles: true
        });
        
        document.dispatchEvent(event);
    }
}

// Initialize when DOM is ready
document.addEventListener('DOMContentLoaded', () => {
    window.dragDropService = new DragDropService();
    window.dragDropService.initialize();
});

// Function to reinitialize drag and drop after DOM updates
window.reinitializeDragDrop = function() {
    if (window.dragDropService) {
        window.dragDropService.initialize();
    }
};