﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusicRenamerSlin_11_2_2020
{
    /*
     * Auteur: Stijn Lingmont
     * Date: 13-03-2020
     * Description: This class provides all the options for the order list.
     */
    public class OrderListSlin
    {
        private ListBox movingFromSlin { get; set; }

        private ListBox movingToSlin { get; set; }

        private MainSlin mainFormSlin;

        public OrderListSlin(MainSlin a_mainFormSlin)
        {
            this.mainFormSlin = a_mainFormSlin;
        }

        //Give the effect of dragging an item
        public void MoveFromListBoxSlin(ListBox a_movingListBoxSlin)
        {
            this.movingFromSlin = a_movingListBoxSlin;

            if (a_movingListBoxSlin.SelectedItem != null)
            {
                a_movingListBoxSlin.DoDragDrop(a_movingListBoxSlin.SelectedItem, DragDropEffects.Move);
            }
        }

        //Give the effect of entering a drop zone
        public void EnterDropRegionSlin(ListBox a_droppingListBoxSlin, DragEventArgs a_enterRegionEventSlin)
        {
            this.movingToSlin = a_droppingListBoxSlin;

            a_enterRegionEventSlin.Effect = DragDropEffects.Move;
        }

        //Add the item in the list it is dropped in
        public void DropInBoxSlin(DragEventArgs a_dragEventSlin)
        {
            Point m_dropInPointSlin = this.movingToSlin.PointToClient(new Point(a_dragEventSlin.X, a_dragEventSlin.Y));
            int m_indexOfBoxSlin = this.movingToSlin.IndexFromPoint(m_dropInPointSlin);
            object m_draggedDataSlin = a_dragEventSlin.Data.GetData(typeof(String));

            //Removing previous item
            if (this.movingFromSlin != null)
                movingFromSlin.Items.Remove(m_draggedDataSlin);
            else
                this.movingToSlin.Items.Remove(m_draggedDataSlin);

            //When you drop the item out of the region with already existing existing items.
            if (m_indexOfBoxSlin < 0)
            {
                if (this.movingToSlin.Items.Count == 0)
                    m_indexOfBoxSlin = 0;
                else
                    m_indexOfBoxSlin = this.movingToSlin.Items.Count;
            }

            this.movingToSlin.Items.Insert(m_indexOfBoxSlin, m_draggedDataSlin); //Insert new Item
        }

        public List<string> GetSelectedItemsSlin()
        {
            List<string> m_orderListItemsSlin = new List<string>();

            foreach(string m_selectedItemSlin in mainFormSlin.lsbSelectedOrderSlin.Items)
            {
                m_orderListItemsSlin.Add(m_selectedItemSlin);
            }

            return m_orderListItemsSlin;
        }
    }
   
}